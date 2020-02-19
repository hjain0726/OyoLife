using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Models
{
    public class ResponseMsg
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public User user { get; set; }
    }
}
