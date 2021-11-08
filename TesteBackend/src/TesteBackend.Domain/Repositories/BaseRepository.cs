using Microsoft.EntityFrameworkCore;

namespace TesteBackend.Domain.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbBackendContext context;
        protected readonly DbSet<T> dbSets;

        public BaseRepository(DbBackendContext context)
        {
            this.context = context;
            this.dbSets = this.context.Set<T>();
        }
    }
}
