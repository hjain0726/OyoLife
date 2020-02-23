using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class PG
    {
        public int Id { get; set; }
        public string Pg_Name { get; set; }
        public double Pg_Price { get; set; }
        public string Pg_Type { get; set; }

        public List<PgImage> Pg_Images { get; set; }
        public string Pg_Sharing { get; set; }
        public string About_Pg { get; set; }
        public Address Pg_Address { get; set; }
        public string Pg_Location { get; set; }

        public List<Facility> Pg_Facilites { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
