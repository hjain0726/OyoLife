using OyoLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OyoLife.Interfaces
{
    public interface IPgImagesRepository
    {
       public List<PgImage> GetPgImages(PG pg);
    }
}
