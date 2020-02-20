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
        public int PGID { get; set; }
        public PG PG { get; set; }
    }
}
