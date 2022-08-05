using Microsoft.EntityFrameworkCore;

namespace TesteAPI.DAL.Interfaces
{
    public interface IContexto
    {
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
