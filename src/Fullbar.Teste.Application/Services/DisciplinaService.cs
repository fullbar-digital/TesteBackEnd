using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Domain.Entities.Validation;
using Fullbar.Teste.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Services
{
    public class DisciplinaService : BaseService, IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository,
                              INotificador notificador) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task Adicionar(Disciplina disciplina)
        {
            if (!ExecutarValidacao(new DisciplinaValidation(), disciplina)) return;

            await _disciplinaRepository.Adicionar(disciplina);
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            if (!ExecutarValidacao(new DisciplinaValidation(), disciplina)) return;

            await _disciplinaRepository.Atualizar(disciplina);
        }

        public async Task Remover(Guid id)
        {
            await _disciplinaRepository.Remover(id);
        }

        public void Dispose()
        {
            _disciplinaRepository?.Dispose();
        }
    }
}