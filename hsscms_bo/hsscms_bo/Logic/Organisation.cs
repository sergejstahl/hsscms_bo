using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsscms_bo.Logic
{
    public class Organisation
    {
        public int id { get; set; }
        public string shortName { get; set; }
        public string titleName { get; set; }
        public string fullName { get; set; }
        public string foundingDate { get; set; }
        public string description { get; set; }
        public City city { get; set; }
    }
}
