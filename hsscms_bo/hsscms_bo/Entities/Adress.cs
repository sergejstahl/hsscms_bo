using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsscms_bo.Entities
{
    public class Adress
    {
        [Key]
        public int id { get; set; }

        public string index { get; set; }

        public string region { get; set; }
        public string street { get; set; }

        public City city { get; set; }
    }
}
