using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyoLife.Data;
using OyoLife.Models;

namespace OyoLife.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PGsController : ControllerBase
    {
        private readonly OyoLifeContext _context;

        public PGsController(OyoLifeContext context)
        {
            _context = context;
        }

        // GET: api/PGs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PG>>> GetPG()
        {
            return await _context.PG.ToListAsync();
        }

        // GET: api/PGs/5
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPG(int id, PG pG)
        {
            if (id != pG.Id)
            {
                return BadRequest();
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
        [HttpPost]
        public async Task<ActionResult<PG>> PostPG(PG pG)
        {
            _context.PG.Add(pG);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPG", new { id = pG.Id }, pG);
        }

        // DELETE: api/PGs/5
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
