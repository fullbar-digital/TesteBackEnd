using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AppAlunos.Business.Services
{
    public class DisciplinaService : BaseService, IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<bool> Adicionar(Disciplina disciplina)
        {

            if (_disciplinaRepository.Buscar(f => f.Nome == disciplina.Nome).Result.Any())
            {
                Notificar("Já existe uma disciplina com este nome cadastrada.");
                return false;
            }

            await _disciplinaRepository.Adicionar(disciplina);
            return true;
        }

        public void Dispose()
        {
            _disciplinaRepository?.Dispose();
        }
    }
}
