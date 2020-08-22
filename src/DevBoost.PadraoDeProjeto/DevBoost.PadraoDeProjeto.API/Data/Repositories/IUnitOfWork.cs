using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.PadraoDeProjeto.API.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IJogadorRepositoy Jogadores { get; }

        void Save();
    }
}
