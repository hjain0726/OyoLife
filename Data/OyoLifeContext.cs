using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OyoLife.Models;

namespace OyoLife.Data
{
    public class OyoLifeContext : DbContext
    {
        public OyoLifeContext (DbContextOptions<OyoLifeContext> options)
            : base(options)
        {
        }

        public DbSet<OyoLife.Models.User> User { get; set; }
    }
}
