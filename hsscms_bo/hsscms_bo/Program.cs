﻿using Newtonsoft.Json;
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

            using (CatalogOrganisationsContext context = new CatalogOrganisationsContext())
            {
                var listCity = context.Cities.Select(x=>x).ToList();

                City city = new City {
                    id = 1,
                    name = "brest"
                };

                var cityitem = context.Cities.Where(x => x.id == 1).FirstOrDefault()  ?? new City {
                    id = 1,
                    name = "brest"
                };

                context.Entry(cityitem).State = EntityState.Added;
                context.SaveChanges();
            }
            
            
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
