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
                    if (!curRow.gorod.Equals(String.Empty))
                    {
                        CheckCity(curRow.gorod);
                    }
                }

                context.SaveChanges();
            }
        }


        private void CheckCity(string strCity)
        {
            City itemCity = null;

            try
            {
                itemCity = context.Cities.Where(x => x.name == strCity).Select(x => x).FirstOrDefault();
            }
            finally
            {
                if (itemCity == null)
                {
                    log.Trace($"{strCity} - add");
                    City curCity = new City { name = strCity };
                    context.Entry(curCity).State = EntityState.Added;
                }
                else
                {
                    log.Trace($"{strCity} - exist");
                }
            }
        }
    }

    public class RowOrgs
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("gorod")]
        public string gorod { get; set; }
    }
}
