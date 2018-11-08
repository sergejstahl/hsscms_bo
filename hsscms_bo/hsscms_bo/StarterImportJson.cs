using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using NLog;
using hsscms_bo.Entities;
using Newtonsoft.Json;

namespace hsscms_bo
{
    public class StarterImportJson
    {
        private CatalogOrganisationsContext context;

        Logger log = LogManager.GetCurrentClassLogger();

        public StarterImportJson() { }

        public void ImportFileJson(string pathJson)
        {
            var strJson = File.ReadAllText(pathJson, System.Text.Encoding.UTF8);
            List<RowOrgs> listOrgs = JsonConvert.DeserializeObject<List<RowOrgs>>(strJson);

            using (context = new CatalogOrganisationsContext())
            {
                //context.Database.Log += log.Trace;

                foreach (var curRow in listOrgs)
                {
                    City city = null;
                    if (curRow.gorod != null && !curRow.gorod.Equals(String.Empty))
                    {
                        city = CheckCity(curRow.gorod);
                    }

                    Organisation itemOrg = context.Organisations.Where(x => x.oid == curRow.id).Select(x => x).FirstOrDefault();
                    if (itemOrg == null)
                    {
                        log.Trace($"{curRow.titul} - add");
                        Organisation curOrganisation = new Organisation { oid = curRow.id, titleName = curRow.titul, city = city };
                        context.Entry(curOrganisation).State = EntityState.Added;
                    }
                    context.SaveChanges();
                }
            }
        }


        private City CheckCity(string strCity)
        {
            City itemCity = null;

            itemCity = context.Cities.Where(x => x.name == strCity).Select(x => x).FirstOrDefault();
            if (itemCity != null)
                return itemCity;

            City curCity = new City { name = strCity };
            context.Entry(curCity).State = EntityState.Added;
            context.SaveChanges();

            log.Trace($"{strCity} - add");

            return curCity;
        }
    }

    public class RowOrgs
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("gorod")]
        public string gorod { get; set; }

        [JsonProperty("titul")]
        public string titul { get; set; }
    }
}
