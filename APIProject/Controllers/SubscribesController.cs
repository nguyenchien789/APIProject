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
    public class SubscribesController : ControllerBase
    {
        private readonly FnewsContext _context = new FnewsContext();

        // GET: api/Subscribes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscribe>>> GetSubscribe()
        {
            return await _context.Subscribe.ToListAsync();
        }

        // GET: api/Subscribes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscribe>> GetSubscribe(int id)
        {
            var subscribe = await _context.Subscribe.FindAsync(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            return subscribe;
        }

        // PUT: api/Subscribes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscribe(int id, Subscribe subscribe)
        {
            if (id != subscribe.ChannelId)
            {
                return BadRequest();
            }

            _context.Entry(subscribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribeExists(id))
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

        // POST: api/Subscribes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subscribe>> PostSubscribe(Subscribe subscribe)
        {
            _context.Subscribe.Add(subscribe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscribeExists(subscribe.ChannelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubscribe", new { id = subscribe.ChannelId }, subscribe);
        }

        // DELETE: api/Subscribes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subscribe>> DeleteSubscribe(int id)
        {
            var subscribe = await _context.Subscribe.FindAsync(id);
            if (subscribe == null)
            {
                return NotFound();
            }

            _context.Subscribe.Remove(subscribe);
            await _context.SaveChangesAsync();

            return subscribe;
        }

        private bool SubscribeExists(int id)
        {
            return _context.Subscribe.Any(e => e.ChannelId == id);
        }
    }
}
