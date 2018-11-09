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

                        Organisation curOrganisation = new Organisation {
                            oid = curRow.id,
                            wyw = curRow.wyw,
                            titleName = curRow.nam,
                            shortName = curRow.titul,
                            fullName = curRow.namep,
                            foundingDate = curRow.dates,
                            description = curRow.opis,
                            city = city
                        };
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

        [JsonProperty("wyw")]
        public int wyw { get; set; }

        [JsonProperty("namep")]
        public string namep { get; set; }

        [JsonProperty("titul")]
        public string titul { get; set; }

        [JsonProperty("nam")]
        public string nam { get; set; }

        [JsonProperty("dates")]
        public string dates { get; set; }

        [JsonProperty("vedom")]
        public string vedom { get; set; }

        [JsonProperty("opis")]
        public string opis { get; set; }

        [JsonProperty("ochta")]
        public string ochta { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("gorod")]
        public string gorod { get; set; }

        [JsonProperty("ulica")]
        public string ulica { get; set; }

        [JsonProperty("rajong")]
        public string rajong { get; set; }

        [JsonProperty("telefon")]
        public string telefon { get; set; }

        [JsonProperty("fax")]
        public string fax { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("towar")]
        public string towar { get; set; }

        [JsonProperty("opistow")]
        public string opistow { get; set; }

        [JsonProperty("znak_ris")]
        public string znak_ris { get; set; }

        [JsonProperty("opisl")]
        public string opisl { get; set; }

        [JsonProperty("opisd")]
        public string opisd { get; set; }

        [JsonProperty("rekl_ris")]
        public string rekl_ris { get; set; }

        [JsonProperty("otrasl")]
        public string otrasl { get; set; }

        [JsonProperty("istor")]
        public string istor { get; set; }

        [JsonProperty("face_ris")]
        public string face_ris { get; set; }

        [JsonProperty("meta")]
        public string meta { get; set; }

        [JsonProperty("data_izm")]
        public string data_izm { get; set; }

        [JsonProperty("sluzebnaja")]
        public string sluzebnaja { get; set; }

        [JsonProperty("sort")]
        public int sort { get; set; }
    }
}
