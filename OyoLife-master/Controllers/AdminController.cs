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
    public class AdminController : ControllerBase
    {
        private readonly OyoLifeContext _context;
        public AdminController(OyoLifeContext context)
        {
            _context = context;
        }

        //GET: api/Admin/Users
        [Authorize(Roles =Role.Admin)]
        [Route("Users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        //GET:api/Admin/Users/5
        [Authorize(Roles = Role.Admin)]
        [HttpGet("Users/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT:api/Admin/EditUserRole/2
        [Authorize(Roles = Role.Admin)]
        [HttpPut("EditUserRole/{id}")]
        public async Task<ActionResult<ResponseMsg>> EditUserRole(int id)
        {
            var user = _context.User.Find(id);
            if (id != user.Id)
            {
                return BadRequest();
            }

            user.Role = Role.Dealer;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                Dealer dealer = new Dealer
                {
                    Id = user.Id,
                    Dealer_Name = user.user_name,
                    Dealer_Email = user.User_Email,
                    Dealer_Password = user.User_Password,
                    Dealer_age = user.user_age,
                    Dealer_gender = user.user_gender,
                    Dealer_PhoneNo = user.user_phone,
                    Role = Role.Dealer,
                    PerDay_DealingCapacity = 5
                };
                _context.Dealer.Add(dealer);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var msg = new ResponseMsg
            {
                Success = true,
                Message = "Role changed successfully"
            };
            return msg;
        }

        // DELETE: api/Admin/Users/3
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("Users/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // GET: api/Admin/Dealers
        [Authorize(Roles = Role.Admin)]
        [Route("Dealers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetDealers()
        {
            return await _context.Dealer.ToListAsync();
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}