using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Facility_Name { get; set; }
        public int PGId { get; set; }
        public PG PG { get; set; }
    }
}
