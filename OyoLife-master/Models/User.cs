using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class User
    {
        public int Id { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string user_name { get; set; }
        public string user_gender { get; set; }
        public int user_age { get; set; }
        public string user_phone { get; set; }
        public string Role { get; set; }

        public ICollection<Booking> Bookings { get; set; }
      
    }
}
