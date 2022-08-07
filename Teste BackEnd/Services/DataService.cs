using Teste_BackEnd.Interfaces;

namespace Teste_BackEnd
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        public DataService(ApplicationContext context)
        {
            this.context = context;
        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
        }
    }
}
