using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyoLife.Data;
using OyoLife.Helpers;
using OyoLife.Models;

namespace OyoLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly OyoLifeContext _context;

        public BookingsController(OyoLifeContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            return await _context.Booking.ToListAsync();
        }

        // GET: api/Bookings/5
        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

     
        // POST: api/Bookings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(Roles = Role.User)]
        [HttpPost]
        public async Task<ActionResult<BookingMsg>> PostBooking(Booking booking)
        {
            BookingAvailability bookingAvailability=_context.BookingAvailabilities.SingleOrDefault(d => d.BookingDate == booking.Booking_Date && d.DealerId==booking.DealerId);
            Dealer dealer = _context.Dealer.SingleOrDefault(d=>d.Id==booking.DealerId);

            if (bookingAvailability == null)
            {
                BookingAvailability bookAvail = new BookingAvailability
                {
                    BookingDate=booking.Booking_Date,
                    DealerId=booking.DealerId,
                    No_Of_Bookings=1
                };

                booking.BookingStatus = "Open";

                _context.BookingAvailabilities.Add(bookAvail);
                _context.Booking.Add(booking);

                var msg = new BookingMsg
                {
                    Success = true,
                    msg = "Booking Done successfully",
                    booking=booking
                };

                await _context.SaveChangesAsync();

                return msg;
            }
            else if (bookingAvailability.No_Of_Bookings<dealer.PerDay_DealingCapacity)
            {
                bookingAvailability.No_Of_Bookings += 1;
                booking.BookingStatus = "Open";

                _context.Entry(bookingAvailability).State = EntityState.Modified;
                _context.Booking.Add(booking);

                var msg = new BookingMsg
                {
                    Success = true,
                    msg = "Booking Done Suceesfully",
                    booking = booking
                };

                await _context.SaveChangesAsync();

                return msg;
            }
            else
            {
                var msg = new BookingMsg
                {
                    Success=false,
                    msg="Booking Not available"
                };
                return msg;
            }
            

            //return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        //GET: api/Bookings/UserBookings/4
        [Authorize(Roles = Role.User)]
        [HttpGet("UserBookings/{userId}")]
        public async Task<ActionResult<List<Booking>>> GetUserBookings(int userId)
        {
            var booking= _context.Booking.Where(b=>b.UserId==userId).ToList();

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        //GET: api/Bookings/DealerBookings/4
        [Authorize(Roles = Role.Dealer)]
        [HttpGet("DealerBookings/{dealerId}")]
        public async Task<ActionResult<List<Booking>>> GetDealerBookings(int dealerId)
        {
            var booking = _context.Booking.Where(b => b.UserId == dealerId).ToList();

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
