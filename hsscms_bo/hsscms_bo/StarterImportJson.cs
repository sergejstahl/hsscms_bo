using hsscms_bo.Entities;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace hsscms_bo
{
    public class StarterImportJson
    {
        private CatalogOrganisationsContext context;

        Logger log = LogManager.GetCurrentClassLogger();

        public StarterImportJson() { }

        public void ImportFileJson(string pathJson)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var strJson = File.ReadAllText(pathJson, System.Text.Encoding.UTF8);
            List<RowOrgs> listOrgs = JsonConvert.DeserializeObject<List<RowOrgs>>(strJson);

            using (context = new CatalogOrganisationsContext())
            {
                //context.Database.Log += log.Trace;

                SynchContactTypes();

                SynchCity(listOrgs);

                var contactTypes = context.ContactTypes.ToList();

                foreach (var itemRow in listOrgs)
                {
                    var itemOrg = context.Organisations.FirstOrDefault(x => x.oid == itemRow.id);
                    if (itemOrg != null)
                        continue;

                    List<Contact> listContacts = new List<Contact>();
                    List<Good> listGoods = new List<Good>();
                    string[] stringSeparators;

                    if (!itemRow.telefon.Equals(String.Empty))
                    {
                        stringSeparators = new string[] { "%:%" };
                        string[] arPhones = itemRow.telefon.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string curStrPhone in arPhones)
                        {
                            stringSeparators = new string[] { "%-%" };
                            string[] arPhone = curStrPhone.Trim().Split(stringSeparators, StringSplitOptions.None);

                            if (arPhone.Count() == 2)
                            {
                                Contact contact = new Contact
                                {
                                    type = context.ContactTypes.FirstOrDefault(x => x.name == "phone"),
                                    description = arPhone[0],
                                    value = arPhone[1]
                                };

                                listContacts.Add(contact);
                            }
                        }
                    }

                    if (!itemRow.fax.Equals(String.Empty))
                    {
                        stringSeparators = new string[] { "," };
                        string[] arFaxes = itemRow.fax.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string curStrFax in arFaxes)
                        {
                            Contact contact = new Contact
                            {
                                type = context.ContactTypes.FirstOrDefault(x => x.name == "fax"),
                                description = String.Empty,
                                value = curStrFax.Trim()
                            };

                            listContacts.Add(contact);
                        }
                    }

                    if (itemRow.email != null && !itemRow.email.Equals(String.Empty))
                    {
                        Contact contact = new Contact
                        {
                            type = context.ContactTypes.FirstOrDefault(x => x.name == "email"),
                            description = String.Empty,
                            value = itemRow.email
                        };

                        listContacts.Add(contact);
                    }

                    if (itemRow.url != null && !itemRow.url.Equals(String.Empty))
                    {
                        Contact contact = new Contact
                        {
                            type = context.ContactTypes.FirstOrDefault(x => x.name == "url"),
                            description = String.Empty,
                            value = itemRow.url
                        };

                        listContacts.Add(contact);
                    }

                    Adress adress = new Adress
                    {
                        index = itemRow.ochta,
                        region = itemRow.region,
                        street = itemRow.ulica,
                        city = context.Cities.FirstOrDefault(x => x.name == itemRow.gorod)
                    };

                    if (!itemRow.towar.Equals(String.Empty))
                    {
                        stringSeparators = new string[] { "%:%" };
                        string[] arGoods = itemRow.towar.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string curStrGood in arGoods)
                        {
                            string newGood = curStrGood.Trim();
                            if (newGood.Equals(String.Empty))
                                continue;

                            var itemGood = context.Goods.FirstOrDefault(x => x.description == newGood);
                            if (itemGood == null)
                            {
                                Good good = new Good { description = newGood };
                                itemGood = good;
                            }

                            listGoods.Add(itemGood);
                        }
                    }

                    Organisation curOrganisation = new Organisation
                    {
                        oid = itemRow.id,
                        wyw = itemRow.wyw,
                        titleName = itemRow.nam,
                        shortName = itemRow.titul,
                        fullName = itemRow.namep,
                        foundingDate = itemRow.dates,
                        description = itemRow.opis,
                        department = itemRow.vedom,
                        adress = adress,
                        contacts = listContacts,
                        goods = listGoods,
                        tmp_opistow = itemRow.opistow,
                        tmp_znak_ris = itemRow.znak_ris,
                        tmp_opisl = itemRow.opisl,
                        tmp_opisd = itemRow.opisd,
                        tmp_rekl_ris = itemRow.rekl_ris,
                        tmp_otrasl = itemRow.otrasl,
                        tmp_istor = itemRow.istor,
                        tmp_face_ris = itemRow.face_ris,
                        tmp_meta = itemRow.meta,
                        tmp_data_izm = itemRow.data_izm,
                        tmp_sluzebnaja = itemRow.sluzebnaja,
                        tmp_sort = itemRow.sort
                    };

                    context.Entry(curOrganisation).State = EntityState.Added;
                    //context.SaveChanges();

                    log.Trace($"Org-Add: {itemRow.titul}");
                }
                context.SaveChanges();
            }

            sw.Stop();
            log.Trace($"Operation time: {sw.ElapsedMilliseconds}");
        }

        private void SynchContactTypes()
        {
            List<string> list = new List<string>();
            list.Add("phone");
            list.Add("fax");
            list.Add("email");
            list.Add("url");

            foreach (string ctName in list)
            {
                var itemContactType = context.ContactTypes.FirstOrDefault(x => x.name == ctName);

                if (itemContactType == null)
                {
                    ContactType contactType = new ContactType { name = ctName };
                    context.Entry(contactType).State = EntityState.Added;
                    context.SaveChanges();

                    log.Trace($"ContactType-Add: {ctName}");
                }
            }
        }

        private void SynchCity(List<RowOrgs> listOrgs)
        {
            foreach (var itemRow in listOrgs)
            {
                if (itemRow.gorod != null && !itemRow.gorod.Equals(String.Empty))
                {
                    var itemCity = context.Cities.FirstOrDefault(x => x.name == itemRow.gorod);
                    if (itemCity != null)
                        continue;

                    City curCity = new City { name = itemRow.gorod };
                    context.Entry(curCity).State = EntityState.Added;
                    context.SaveChanges();

                    log.Trace($"City-Add: {itemRow.gorod}");

                }
            }
        }
    }

    public class RowOrgs
    {
        [JsonProperty("id")]
        public int id { get; set; } //

        [JsonProperty("wyw")]
        public int wyw { get; set; }    //

        [JsonProperty("namep")]
        public string namep { get; set; }   //

        [JsonProperty("titul")]
        public string titul { get; set; }   //

        [JsonProperty("nam")]
        public string nam { get; set; } //

        [JsonProperty("dates")]
        public string dates { get; set; }   //

        [JsonProperty("vedom")]
        public string vedom { get; set; }   //

        [JsonProperty("opis")]
        public string opis { get; set; } //

        [JsonProperty("ochta")]
        public string ochta { get; set; }   //

        [JsonProperty("region")]
        public string region { get; set; }  //

        [JsonProperty("gorod")]
        public string gorod { get; set; }   //

        [JsonProperty("ulica")]
        public string ulica { get; set; }   //

        [JsonProperty("rajong")]
        public string rajong { get; set; }  // del

        [JsonProperty("telefon")]
        public string telefon { get; set; } //

        [JsonProperty("fax")]
        public string fax { get; set; } //

        [JsonProperty("email")]
        public string email { get; set; }   //

        [JsonProperty("url")]
        public string url { get; set; } //

        [JsonProperty("towar")]
        public string towar { get; set; } //

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
