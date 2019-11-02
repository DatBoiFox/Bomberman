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
    public class BombsController : ControllerBase
    {
        private readonly GameContext _context;

        public BombsController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Bombs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bomb>>> GetBomb()
        {
            return await _context.Bomb.ToListAsync();
        }

        // GET: api/Bombs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bomb>> GetBomb(int id)
        {
            var bomb = await _context.Bomb.FindAsync(id);

            if (bomb == null)
            {
                return NotFound();
            }

            return bomb;
        }

        // PUT: api/Bombs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBomb(int id, Bomb bomb)
        {
            if (id != bomb.id)
            {
                return BadRequest();
            }

            _context.Entry(bomb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BombExists(id))
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

        // POST: api/Bombs
        [HttpPost]
        public async Task<ActionResult<Bomb>> PostBomb(Bomb bomb)
        {
            _context.Bomb.Add(bomb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBomb", new { id = bomb.id }, bomb);
        }

        // DELETE: api/Bombs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bomb>> DeleteBomb(int id)
        {
            var bomb = await _context.Bomb.FindAsync(id);
            if (bomb == null)
            {
                return NotFound();
            }

            _context.Bomb.Remove(bomb);
            await _context.SaveChangesAsync();

            return bomb;
        }

        private bool BombExists(int id)
        {
            return _context.Bomb.Any(e => e.id == id);
        }
    }
}
