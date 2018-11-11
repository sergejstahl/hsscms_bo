using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsscms_bo.Entities
{
    public class Organisation
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int oid { get; set; }

        public int wyw { get; set; }

        public string shortName { get; set; }
        public string titleName { get; set; }
        public string fullName { get; set; }

        public string foundingDate { get; set; }
        public string description { get; set; }

        public string department { get; set; }

        public Adress adress { get; set; }
        public List<Contact> contacts { get; set; }
        public List<Good> goods { get; set; }

        public string tmp_opistow { get; set; }
        public string tmp_znak_ris { get; set; }
        public string tmp_opisl { get; set; }
        public string tmp_opisd { get; set; }
        public string tmp_rekl_ris { get; set; }
        public string tmp_otrasl { get; set; }
        public string tmp_istor { get; set; }
        public string tmp_face_ris { get; set; }
        public string tmp_meta { get; set; }
        public string tmp_data_izm { get; set; }
        public string tmp_sluzebnaja { get; set; }
        public int tmp_sort { get; set; }
    }
}
