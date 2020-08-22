using Microsoft.EntityFrameworkCore;
using DevBoost.PadraoDeProjeto.API.Entities;
using DevBoost.PadraoDeProjeto.API.Data.Contexts;

namespace DevBoost.PadraoDeProjeto.API.Data
{
    public class DevBoosContext : DbContext
    {
        public DevBoosContext (DbContextOptions<DevBoosContext> options)
            : base(options)
        {

        }

        public DbSet<Jogador> Jogador { get; set; }
    }
}
