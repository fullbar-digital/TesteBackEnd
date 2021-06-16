using System.Threading.Tasks;
namespace School_Manager.Persistence
{
    public class GenericaPersistence : IGenerica
    {
        private readonly DataContext context;

        public GenericaPersistence(DataContext _context)
        {

            context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);

        }

        public void DeleteRanger<T>(T[] entityArray) where T : class
        {
            context.Add(entityArray);
        }

        public async Task<bool> SalveChangesAsync()
        {
            return (await context.SalveChangesAsync()) > 0;
        }

    }
}