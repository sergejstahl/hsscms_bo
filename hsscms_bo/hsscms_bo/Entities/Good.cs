using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsscms_bo.Entities
{
    public class Good
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string description { get; set; }
    }
}
