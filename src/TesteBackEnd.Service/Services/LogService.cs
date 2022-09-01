using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Services
{
    public class LogService : BaseService, ILogService
    {
        private ILogRepository _repository;
        public LogService(INotifier notifier, ILogRepository repository) : base(notifier)
        {
            _repository = repository;
        }
    }
}
