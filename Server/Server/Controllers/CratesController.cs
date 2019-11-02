using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CratesController : ControllerBase
    {
        private readonly GameContext _context;

        public CratesController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Crates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crate>>> GetCrate()
        {
            return await _context.Crate.ToListAsync();
        }

        // GET: api/Crates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crate>> GetCrate(int id)
        {
            var crate = await _context.Crate.FindAsync(id);

            if (crate == null)
            {
                return NotFound();
            }

            return crate;
        }

        // PUT: api/Crates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrate(int id, Crate crate)
        {
            if (id != crate.id)
            {
                return BadRequest();
            }

            _context.Entry(crate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrateExists(id))
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

        // POST: api/Crates
        [HttpPost]
        public async Task<ActionResult<Crate>> PostCrate(Crate crate)
        {
            _context.Crate.Add(crate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrate", new { id = crate.id }, crate);
        }

        // DELETE: api/Crates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crate>> DeleteCrate(int id)
        {
            var crate = await _context.Crate.FindAsync(id);
            if (crate == null)
            {
                return NotFound();
            }

            _context.Crate.Remove(crate);
            await _context.SaveChangesAsync();

            return crate;
        }

        private bool CrateExists(int id)
        {
            return _context.Crate.Any(e => e.id == id);
        }
    }
}
