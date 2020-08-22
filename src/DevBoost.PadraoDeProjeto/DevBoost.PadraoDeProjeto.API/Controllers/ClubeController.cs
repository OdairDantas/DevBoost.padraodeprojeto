using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevBoost.PadraoDeProjeto.API.Data;
using DevBoost.PadraoDeProjeto.API.Entities;

namespace DevBoost.PadraoDeProjeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubeController : ControllerBase
    {
        private readonly DevBoosContext _context;

        public ClubeController(DevBoosContext context)
        {
            _context = context;
        }

        // GET: api/Clube
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clube>>> GetClube()
        {
            return await _context.Clube.ToListAsync();
        }

        // GET: api/Clube/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clube>> GetClube(int id)
        {
            var clube = await _context.Clube.FindAsync(id);

            if (clube == null)
            {
                return NotFound();
            }

            return clube;
        }

        // PUT: api/Clube/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClube(int id, Clube clube)
        {
            if (id != clube.Id)
            {
                return BadRequest();
            }

            _context.Entry(clube).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubeExists(id))
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

        // POST: api/Clube
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Clube>> PostClube(Clube clube)
        {
            _context.Clube.Add(clube);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClube", new { id = clube.Id }, clube);
        }

        // DELETE: api/Clube/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clube>> DeleteClube(int id)
        {
            var clube = await _context.Clube.FindAsync(id);
            if (clube == null)
            {
                return NotFound();
            }

            _context.Clube.Remove(clube);
            await _context.SaveChangesAsync();

            return clube;
        }

        private bool ClubeExists(int id)
        {
            return _context.Clube.Any(e => e.Id == id);
        }
    }
}
