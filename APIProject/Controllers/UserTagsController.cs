using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTagsController : ControllerBase
    {
        private readonly FnewsContext _context = new FnewsContext();

        // GET: api/UserTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTag>>> GetUserTag()
        {
            return await _context.UserTag.ToListAsync();
        }

        // GET: api/UserTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTag>> GetUserTag(int id)
        {
            var userTag = await _context.UserTag.FindAsync(id);

            if (userTag == null)
            {
                return NotFound();
            }

            return userTag;
        }

        // PUT: api/UserTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTag(int id, UserTag userTag)
        {
            if (id != userTag.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTagExists(id))
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

        // POST: api/UserTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserTag>> PostUserTag(UserTag userTag)
        {
            _context.UserTag.Add(userTag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTagExists(userTag.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTag", new { id = userTag.UserId }, userTag);
        }

        // DELETE: api/UserTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTag>> DeleteUserTag(int id)
        {
            var userTag = await _context.UserTag.FindAsync(id);
            if (userTag == null)
            {
                return NotFound();
            }

            _context.UserTag.Remove(userTag);
            await _context.SaveChangesAsync();

            return userTag;
        }

        private bool UserTagExists(int id)
        {
            return _context.UserTag.Any(e => e.UserId == id);
        }
    }
}
