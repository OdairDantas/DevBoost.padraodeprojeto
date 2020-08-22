using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevBoost.PadraoDeProjeto.API.Data;
using DevBoost.PadraoDeProjeto.API.Entities;
using DevBoost.PadraoDeProjeto.API.Data.Repositories;

namespace DevBoost.PadraoDeProjeto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JogadorController(IUnitOfWork unitOfWork)
        {

            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Jogador>> GetAll()
        {
            var jogador = _unitOfWork.Jogadores.GetAll();

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }
        // GET: api/Jogador/5
        [HttpGet("{id}")]
        public ActionResult<Jogador> GetJogador(int id)
        {
            var jogador = _unitOfWork.Jogadores.GetById(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }


        // POST: api/Jogador
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Jogador> PostJogador(Jogador jogador)
        {
            _unitOfWork.Jogadores.Insert(jogador);
            _unitOfWork.Save();

            return CreatedAtAction("GetJogador", new { id = jogador.Id }, jogador);
        }

        // DELETE: api/Jogador/5
        [HttpDelete("{id}")]
        public ActionResult<Jogador> DeleteJogador(int id)
        {
            var jogador = _unitOfWork.Jogadores.GetById(id);
            if (jogador == null)
            {
                return NotFound();
            }

            _unitOfWork.Jogadores.Delete(jogador);
            _unitOfWork.Save();

            return jogador;
        }

    }
}
