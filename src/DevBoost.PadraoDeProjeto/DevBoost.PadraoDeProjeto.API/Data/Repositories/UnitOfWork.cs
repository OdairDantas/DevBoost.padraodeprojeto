using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.PadraoDeProjeto.API.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevBoosContext _context;

        public UnitOfWork(DevBoosContext context)
        {
            _context = context;
            Jogadores = new JogadorRepository(_context);
        }

        public IJogadorRepositoy Jogadores { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
