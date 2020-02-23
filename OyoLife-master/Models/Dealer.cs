using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Dealer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Dealer_Name { get; set; }
        public string Dealer_Email { get; set; }
        public string Dealer_Password { get; set; }
        public string Dealer_PhoneNo { get; set; }
        public string Dealer_gender { get; set; }
        public int Dealer_age { get; set; }
        public string Role { get; set; }

        public ICollection<PG> PGs { get; set; }

        //public List<PG> PgList { get; set; }

    }
}
