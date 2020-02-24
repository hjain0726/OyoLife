using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Booking_Date { get; set; }
        public string Booking_Time { get; set; }
        public int PGId { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
        
        //public PG PG { get; set; }
    }
}
