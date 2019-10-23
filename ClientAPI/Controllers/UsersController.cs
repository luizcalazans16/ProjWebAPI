using System;
using System.Collections.Generic;
using System.Linq;
using ClientAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ClientAPIDbContext _context;

        public UsersController(ClientAPIDbContext context)
        {
            _context = context;
        }

        //GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                var result = await _context.Users.ToListAsync();
                if (result.Any())
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        //GET: api/User/S
        [HttpGet("{id}")]
        
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _context.Users.FindAsync(id);
                if(result != null)
                {
                    return result;
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //POST
        [HttpPost]

        public async Task<ActionResult> Post(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //UPDATE
        [HttpPut]

        public async Task<ActionResult> Put([FromBody]User user)
        {
            try
            {
                var getUser = await _context.Users.FindAsync(user.id);
                if (getUser != null)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //DELETE
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var dlt = await _context.Users.FindAsync(id);
                if (dlt != null)
                {
                    _context.Users.RemoveRange(dlt);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    
    }

}