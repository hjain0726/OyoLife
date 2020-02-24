using OyoLife.Data;
using OyoLife.Interfaces;
using OyoLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Repositories
{
    public class PgFacilityRepository : IPgFacilityRepository
    {
        private readonly OyoLifeContext _context;

        public PgFacilityRepository(OyoLifeContext oyoLifeContext)
        {
            _context = oyoLifeContext;
        }
        public List<Facility> GetPgFacilities(PG pg)
        {
            var facilityList = _context.Facilities.Where(fac => fac.PGId == pg.Id).ToList();
            return facilityList;
        }
    }
}
