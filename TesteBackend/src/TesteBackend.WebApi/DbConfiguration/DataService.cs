using Microsoft.EntityFrameworkCore;
using TesteBackend.Domain;

namespace TesteBackend.WebApi.DbConfiguration
{
    public class DataService : IDataService
    {
        private readonly DbBackendContext context;

        public DataService(DbBackendContext context)
        {
            this.context = context;
        }

        public void InicializeDb()
        {
            this.context.Database.Migrate();
        }
    }
}
