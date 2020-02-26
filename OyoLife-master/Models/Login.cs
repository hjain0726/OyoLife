using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
    }
}
