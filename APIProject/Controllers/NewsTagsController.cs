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
    public class NewsTagsController : ControllerBase
    {
        private readonly FnewsContext _context = new FnewsContext();

        // GET: api/NewsTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsTag>>> GetNewsTag()
        {
            return await _context.NewsTag.ToListAsync();
        }

        // GET: api/NewsTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsTag>> GetNewsTag(int id)
        {
            var newsTag = await _context.NewsTag.FindAsync(id);

            if (newsTag == null)
            {
                return NotFound();
            }

            return newsTag;
        }

        // PUT: api/NewsTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsTag(int id, NewsTag newsTag)
        {
            if (id != newsTag.TagId)
            {
                return BadRequest();
            }

            _context.Entry(newsTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsTagExists(id))
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

        // POST: api/NewsTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NewsTag>> PostNewsTag(NewsTag newsTag)
        {
            _context.NewsTag.Add(newsTag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewsTagExists(newsTag.TagId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewsTag", new { id = newsTag.TagId }, newsTag);
        }

        // DELETE: api/NewsTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsTag>> DeleteNewsTag(int id)
        {
            var newsTag = await _context.NewsTag.FindAsync(id);
            if (newsTag == null)
            {
                return NotFound();
            }

            _context.NewsTag.Remove(newsTag);
            await _context.SaveChangesAsync();

            return newsTag;
        }

        private bool NewsTagExists(int id)
        {
            return _context.NewsTag.Any(e => e.TagId == id);
        }
    }
}
