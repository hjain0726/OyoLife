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
        public string Pg_Sharing { get; set; }
        public string About_Pg { get; set; }
        public Address Pg_Address { get; set; }
        public string Pg_Location { get; set; }
        public ICollection<PgImage> PgImages { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }

        // public ICollection<Booking> Bookings { get; set; }
    }
}
