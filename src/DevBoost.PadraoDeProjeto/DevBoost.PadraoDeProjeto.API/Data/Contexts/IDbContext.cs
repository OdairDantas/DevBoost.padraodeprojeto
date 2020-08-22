using Microsoft.EntityFrameworkCore;

namespace DevBoost.PadraoDeProjeto.API.Data.Contexts
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

        int SaveChanges();

        void Dispose();

    }
}
