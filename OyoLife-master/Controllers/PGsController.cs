using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyoLife.Data;
using OyoLife.Interfaces;
using OyoLife.Models;

namespace OyoLife.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PGsController : ControllerBase
    {
        private readonly OyoLifeContext _context;
        private readonly IPgImagesRepository _IPgImagesRepository;
        private readonly IPgFacilityRepository _IPgFacilityRepository;

        public PGsController(OyoLifeContext context, IPgImagesRepository IPgImagesRepository,IPgFacilityRepository IPgFacilityRepository)
        {
            _context = context;
            _IPgImagesRepository = IPgImagesRepository;
            _IPgFacilityRepository = IPgFacilityRepository;
        }

        // GET: api/PGs
        [Authorize(Roles = Role.Admin +","+Role.User)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PG>>> GetPG()
        {
            var PgList = _context.PG.ToList();
            foreach(PG pg in PgList)
            {
                pg.PgImages = _IPgImagesRepository.GetPgImages(pg);
                pg.Facilities = _IPgFacilityRepository.GetPgFacilities(pg);
                pg.Pg_Address = _context.Address.FirstOrDefault(a => a.PGId == pg.Id);
                pg.Dealer=_context.Dealer.FirstOrDefault(a => a.Id == pg.DealerId);
            }
            return PgList;
            //return await _context.PG.ToListAsync();
        }

        // GET: api/PGs/DealerPgs/2
        [Authorize(Roles = Role.Dealer)]
        [HttpGet("DealerPgs/{DealerId}")]
        public async Task<ActionResult<IEnumerable<PG>>> GetDealerPg(int DealerId)
        {
            var PgList = _context.PG.Where(P => P.DealerId == DealerId).ToList();
            //var PgList = _context.PG.ToList();
            foreach (PG pg in PgList)
            {
                pg.PgImages = _IPgImagesRepository.GetPgImages(pg);
                pg.Facilities = _IPgFacilityRepository.GetPgFacilities(pg);
                pg.Pg_Address = _context.Address.FirstOrDefault(a => a.PGId == pg.Id);
                pg.Dealer = _context.Dealer.FirstOrDefault(a => a.Id == pg.DealerId);
            }
            return PgList;
            //return await _context.PG.ToListAsync();
        }

        // GET: api/PGs/5
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PG>> GetPG(int id)
        {
            var pG = await _context.PG.FindAsync(id);

            if (pG == null)
            {
                return NotFound();
            }

            return pG;
        }

        // PUT: api/PGs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(Roles = Role.Dealer)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPG(int id, PG pG)
        {
            if (id != pG.Id)
            {
                return BadRequest();
            }
           
            var ExistingPgImages = _IPgImagesRepository.GetPgImages(pG);
            var ExistingPgFacilities = _IPgFacilityRepository.GetPgFacilities(pG);

            //Edit Address
            Address addr = pG.Pg_Address;
            _context.Entry(addr).State = EntityState.Modified;

            //For editing Images
            foreach (var image in ExistingPgImages)
            {
                if (!pG.PgImages.Any(c => c.Image_Url == image.Image_Url))
                {
                    _context.PgImages.Remove(image);
                    Console.WriteLine("Image removed");
                }
                    
            }

            foreach (var image in pG.PgImages)
            {
                var existingImage = ExistingPgImages.FirstOrDefault(x => x.Image_Url == image.Image_Url);

                if (existingImage != null)
                {
                    Console.WriteLine("Images exist");
                }
                else
                {
                    // Insert child
                    var PgImage = new PgImage
                    {
                        PGId=pG.Id,
                        Image_Url = image.Image_Url
                    };
                    _context.PgImages.Add(PgImage);
                    Console.WriteLine("New Image added");
                }
            }

            //for Editing Facility
            foreach (var facility in ExistingPgFacilities)
            {
                if (!pG.Facilities.Any(c => c.Facility_Name == facility.Facility_Name))
                {
                    _context.Facilities.Remove(facility);
                    Console.WriteLine("facility removed");
                }

            }

            foreach (var facility in pG.Facilities)
            {
                var existingFacility = ExistingPgFacilities.FirstOrDefault(x => x.Facility_Name == facility.Facility_Name);

                if (existingFacility != null)
                {
                    Console.WriteLine("Facility exist");
                }
                else
                {
                    // Insert child
                    var PgFacility = new Facility
                    {
                        PGId = pG.Id,
                        Facility_Name=facility.Facility_Name
                    };
                    _context.Facilities.Add(PgFacility);
                    Console.WriteLine("New Facility added");
                }
            }
            _context.Entry(pG).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PGExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PGs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(Roles = Role.Dealer)]
        [HttpPost]
        public async Task<ActionResult<PG>> PostPG(PG pG)
        {
                // Do something with the product (not shown).
                _context.PG.Add(pG);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPG", new { id = pG.Id }, pG);
        }

        // DELETE: api/PGs/5
        [Authorize(Roles = Role.Dealer)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PG>> DeletePG(int id)
        {
            var pG = await _context.PG.FindAsync(id);
            if (pG == null)
            {
                return NotFound();
            }

            _context.PG.Remove(pG);
            await _context.SaveChangesAsync();

            return pG;
        }

        private bool PGExists(int id)
        {
            return _context.PG.Any(e => e.Id == id);
        }
    }
}
