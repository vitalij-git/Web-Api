﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public int TelNumber { get; set; }
        public string Birthdate { get; set; }

    }
}
