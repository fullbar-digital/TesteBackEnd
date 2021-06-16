using System.Threading.Tasks;

namespace School_Manager.Persistence
{
    public interface IGenerica
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRanger<T>(T[] entity) where T : class;


        Task<bool> SalveChangesAsync();
    }
}