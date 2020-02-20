using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Dealer_Name { get; set; }
        public string Dealer_Email { get; set; }
        public string Dealer_PhoneNo { get; set; }

        public Address Dealer_Address { get; set; }

    }
}
