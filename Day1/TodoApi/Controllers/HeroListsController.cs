using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroListsController : ControllerBase
    {
        private readonly DbsContext _context;

        public HeroListsController(DbsContext context)
        {
            _context = context;
        }

        // GET: api/HeroLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroList>>> GetHeroLists()
        {
          if (_context.HeroLists == null)
          {
              return NotFound();
          }
            return await _context.HeroLists.ToListAsync();
        }

        // GET: api/HeroLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroList>> GetHeroList(long id)
        {
          if (_context.HeroLists == null)
          {
              return NotFound();
          }
            var heroList = await _context.HeroLists.FindAsync(id);

            if (heroList == null)
            {
                return NotFound();
            }

            return heroList;
        }

        // PUT: api/HeroLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroList(long id, HeroList heroList)
        {
            if (id != heroList.Id)
            {
                return BadRequest();
            }

            _context.Entry(heroList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroListExists(id))
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

        // POST: api/HeroLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeroList>> PostHeroList(HeroList heroList)
        {
          if (_context.HeroLists == null)
          {
              return Problem("Entity set 'DbsContext.HeroLists'  is null.");
          }
            _context.HeroLists.Add(heroList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroList", new { id = heroList.Id }, heroList);
        }

        // DELETE: api/HeroLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroList(long id)
        {
            if (_context.HeroLists == null)
            {
                return NotFound();
            }
            var heroList = await _context.HeroLists.FindAsync(id);
            if (heroList == null)
            {
                return NotFound();
            }

            _context.HeroLists.Remove(heroList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroListExists(long id)
        {
            return (_context.HeroLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
