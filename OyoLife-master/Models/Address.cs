﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int PGId { get; set; }
        public PG PG { get; set; }
    }
}
