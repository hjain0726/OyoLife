using OyoLife.Data;
using OyoLife.Interfaces;
using OyoLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Repositories
{
    public class PgImagesRepository:IPgImagesRepository
    {
        private readonly OyoLifeContext _context;

        public PgImagesRepository(OyoLifeContext oyoLifeContext)
        {
            _context = oyoLifeContext;
        }
        List<PgImage> IPgImagesRepository.GetPgImages(PG pg)
        {
            var imagesList = _context.PgImages.Where(img => img.PGId == pg.Id).ToList();
            return imagesList;
        }
    }
}
