using DevBoost.PadraoDeProjeto.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.PadraoDeProjeto.API.Data.Repositories
{
    public class JogadorRepository : EFRepository<Jogador>, IJogadorRepositoy
    {
        private readonly DevBoosContext _context;

        public JogadorRepository(DevBoosContext context) : base(context)
        {
            this._context = context;
        }
    }
}
