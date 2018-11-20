using dal.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace dal.Tools
{
    public class GenerationPages
    {
        private CatalogOrganisationsContext context;

        Logger log = LogManager.GetCurrentClassLogger();

        public GenerationPages() { }

        public string GenerationOrganisation()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string stringExeption = null;
            try
            {
                using (context = new CatalogOrganisationsContext())
                {
                    //var organisations = context.Organisations.GroupBy(g => new { region = g.adress.region}).Select(s=> s).ToList();
                    //var organisations = context.Organisations.GroupBy(g => new { region = g.adress.region }).ToList();

                    //foreach (var curReg in organisations)
                    //{
                    //    //curReg.Key;
                    //    foreach (var curOrg in curReg)
                    //    {
                    //        //curOrg.adress
                    //    }
                    //}

                    var org = context.Organisations.ToList();
                    var good = context.Goods.ToList();
                    var adr = context.Adreses.ToList();
                    var con = context.Contacts.ToList();

                    //var organisations = context.Organisations.ToList();
                    //foreach (var curOrg in organisations)
                    //{
                    //    foreach (var curGood in curOrg.goods)
                    //    {

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                stringExeption = ex.ToString();
            }

            sw.Stop();
            string timeSec = (sw.ElapsedMilliseconds / 1000).ToString();

            return timeSec;
        }
    }
}
