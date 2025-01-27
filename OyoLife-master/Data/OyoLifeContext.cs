﻿using System;
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

        public DbSet<OyoLife.Models.PG> PG { get; set; }
        public DbSet<OyoLife.Models.Booking> Booking { get; set; }
        public DbSet<OyoLife.Models.Dealer> Dealer { get; set; }
        public DbSet<OyoLife.Models.PgImage> PgImages { get; set; }
        public DbSet<OyoLife.Models.Facility> Facilities { get; set; }
        public DbSet<OyoLife.Models.Address> Address { get; set; }
        public DbSet<OyoLife.Models.BookingAvailability> BookingAvailabilities { get; set; }
    }
}
