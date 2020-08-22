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
    public class PosicaoController : ControllerBase
    {
        private readonly DevBoosContext _context;

        public PosicaoController(DevBoosContext context)
        {
            _context = context;
        }

        // GET: api/Posicao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posicao>>> GetPosicao()
        {
            return await _context.Posicao.ToListAsync();
        }

        // GET: api/Posicao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Posicao>> GetPosicao(int id)
        {
            var posicao = await _context.Posicao.FindAsync(id);

            if (posicao == null)
            {
                return NotFound();
            }

            return posicao;
        }

        // PUT: api/Posicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosicao(int id, Posicao posicao)
        {
            if (id != posicao.Id)
            {
                return BadRequest();
            }

            _context.Entry(posicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosicaoExists(id))
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

        // POST: api/Posicao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Posicao>> PostPosicao(Posicao posicao)
        {
            _context.Posicao.Add(posicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosicao", new { id = posicao.Id }, posicao);
        }

        // DELETE: api/Posicao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Posicao>> DeletePosicao(int id)
        {
            var posicao = await _context.Posicao.FindAsync(id);
            if (posicao == null)
            {
                return NotFound();
            }

            _context.Posicao.Remove(posicao);
            await _context.SaveChangesAsync();

            return posicao;
        }

        private bool PosicaoExists(int id)
        {
            return _context.Posicao.Any(e => e.Id == id);
        }
    }
}
