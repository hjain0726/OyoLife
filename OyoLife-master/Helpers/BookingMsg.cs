using OyoLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Helpers
{
    public class BookingMsg
    {
        public bool Success { get; set; }
        public string msg { get; set; }

        public Booking booking { get; set; }
    }
}
