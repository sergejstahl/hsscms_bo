using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Entities
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Required]
        public ContactType type { get; set; }

        public string description { get; set; }

        public string value { get; set; }
    }
}
