﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hsscms_bo.Entities
{
    public class ContactType
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
    }
}
