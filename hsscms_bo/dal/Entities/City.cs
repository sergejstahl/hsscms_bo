using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Entities
{
    public class City
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }
    }
}
