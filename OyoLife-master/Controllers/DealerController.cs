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
    public class DealerController : ControllerBase
    {
        private readonly OyoLifeContext _context;
        public DealerController(OyoLifeContext context)
        {
            _context = context;
        }

        //GET: api/Dealer/EditBookingStatus/1
        [Authorize(Roles = Role.Dealer)]
        [HttpPut("EditBookingStatus/{BookingId}")]
        public async Task<IActionResult> PutBooking(int BookingId)
        {
            var booking = _context.Booking.SingleOrDefault(b => b.Id == BookingId);
            
            if (booking != null)
            {
                booking.BookingStatus = "Close";
                _context.Entry(booking).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(BookingId))
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
        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}