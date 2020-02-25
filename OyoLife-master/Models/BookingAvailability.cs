using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class BookingAvailability
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int No_Of_Bookings { get; set; }
        public int DealerId { get; set; }
    }
}
