using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OyoLife.Data;
using OyoLife.Helpers;
using OyoLife.Models;

namespace OyoLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OyoLifeContext _context;
        private readonly AppSettings _appSettings;

        public UsersController(OyoLifeContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

       
        [Authorize(Roles = Role.User)]
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
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

            return NoContent();
        }

       
        // POST: api/Users/Register
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<ResponseMsg>> Register([FromBody]User user)
        {
            var userobj = await _context.User.FirstOrDefaultAsync(u => u.User_Email == user.User_Email) ;
            if (userobj != null)
            {
                var msg = new ResponseMsg
                {
                    Success = false,
                    Message= "User Already Exists"
                };
                return msg;
            }
            else
            {
               if(_context.User.Count() == 0)
                {
                    user.Role = Role.Admin;
                }
                else
                {
                    user.Role = Role.User;
                }
                
               user.User_Password= await user.Encrypt(user.User_Password);
               _context.User.Add(user);
               await _context.SaveChangesAsync();

                var userobject = await _context.User.FirstOrDefaultAsync(u => u.User_Email == user.User_Email);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userobject.Id.ToString()),
                    new Claim(ClaimTypes.Role, userobject.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var msg = new ResponseMsg
                {
                    Token = tokenHandler.WriteToken(token),
                    Success=true,
                    user_id = userobject.Id,
                    Message ="successfully register"
                };

                

                return msg;
                //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
           
        }
        // POST: api/Users/Signin
        [AllowAnonymous]
        [Route("Signin")]
        [HttpPost]
        public async Task<ActionResult<ResponseMsg>> Signin([FromBody]Login user)
        {
            var userobj = await _context.User.FirstOrDefaultAsync(u => u.User_Email == user.User_Email);
            if (userobj == null)
            {
                var msg = new ResponseMsg
                {
                    Success = false,
                    Message = "User not found"
                };
                return msg;
            }
            var password = await user.Decrypt(userobj.User_Password);

            if (user.User_Password == password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userobj.Id.ToString()),
                    new Claim(ClaimTypes.Role, userobj.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var msg = new ResponseMsg
                {
                    Token = tokenHandler.WriteToken(token),
                    user_id = userobj.Id,
                    Success = true,
                    Message = "Successfully Login"

                };
                return msg;
            }
            else
            {
                var msg = new ResponseMsg
                {
                    Success = false,
                    Message = "Wrong Email or password"
                };
                return msg;
            }
            
            

        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
