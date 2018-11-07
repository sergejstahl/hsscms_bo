using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using hsscms_bo.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace hsscms_bo
{
    class Program
    {
        static void Main(string[] args)
        {

            int iNew = 0;
            int iUpdate = 0;
            int iExist = 0;

            using (CatalogOrganisationsContext context = new CatalogOrganisationsContext())
            {
                var listCity = context.Cities.Select(x => x).ToList();

                List<City> listNewCities = new List<City>();
                listNewCities.Add(new City { id = 1, name = "Brest" });
                listNewCities.Add(new City { id = 2, name = "Baranovichi" });
                listNewCities.Add(new City { id = 3, name = "Pinsk" });
                listNewCities.Add(new City { id = 4, name = "Kamenec" });

                //IQueryable<City> iqCities = context.Cities.Where(x => listNewCities.Contains(x));

                foreach (City curCity in listNewCities)
                {
                    City curContextCity;

                    try
                    {
                        curContextCity = context.Cities.Where(x => x.id == curCity.id).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        curContextCity = null;
                    }


                    if (curContextCity == null)
                    {
                        context.Entry(curCity).State = EntityState.Added;

                        iNew++;
                    }
                    else
                    {
                        if (!(curContextCity.name.Equals(curCity.name) && curContextCity.id.Equals(curCity.id)))
                        {
                            curContextCity.id = curCity.id;
                            curContextCity.name = curCity.name;
                            context.Entry(curContextCity).State = EntityState.Modified;

                            iUpdate++;
                        }
                        else
                        {
                            iExist++;
                        }
                    }
                }

                context.SaveChanges();
            }

            Console.WriteLine($"new={iNew}, update={iUpdate}, exist={iExist}");
            Console.Read();

            //string pathJson = @"G:\rep\hsscms_bo\predpr2.json";
            //var strJson = File.ReadAllText(pathJson, System.Text.Encoding.UTF8);
            //JToken token = JObject.Parse(strJson);

            //var tt = token.Select(x => x).ToList();


            //List<RowTest> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RowTest>>(strJson);
            //var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RowA>>(strJson);

            //foreach (var root in token)
            //{
            //    foreach (var app in root)
            //    {


            //        foreach (var app2 in app)
            //        {

            //        }
            //        //var appName = app.Key;
            //        //var description = (String)app.Value["Description"];
            //        //var value = (String)app.Value["Value"];

            //            //Console.WriteLine(appName);
            //            //Console.WriteLine(description);
            //            //Console.WriteLine(value);
            //            //Console.WriteLine("\n");
            //    }
            //}

        }
    }

    public class RowA
    {
        [JsonProperty("a")]
        public RowTest a { get; set; }
    }

    public class RowTest
    {
        [JsonProperty(PropertyName = "id")]
        public int AppName { get; set; }

        [JsonProperty(PropertyName = "wyw")]
        public int wyw { get; set; }

        [JsonProperty(PropertyName = "namep")]
        public string namep { get; set; }
    }
}



///*Delete from [CatalogOrganisations].[dbo].[Cities];

//DBCC CHECKIDENT ("[CatalogOrganisations].[dbo].[Cities]", RESEED, 0);*/


//SELECT TOP(1000) [id]
//      ,[name]
//FROM[CatalogOrganisations].[dbo].[Cities];