using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Domain.Entities.Validation;
using Fullbar.Teste.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Services
{
    public class CursoService : BaseService, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository,
                              INotificador notificador) : base(notificador)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task Adicionar(Curso curso)
        {
            if (!ExecutarValidacao(new CursoValidation(), curso)) return;

            await _cursoRepository.Adicionar(curso);
        }

        public async Task Atualizar(Curso curso)
        {
            if (!ExecutarValidacao(new CursoValidation(), curso)) return;

            await _cursoRepository.Atualizar(curso);
        }

        public async Task Remover(Guid id)
        {
            await _cursoRepository.Remover(id);
        }

        public void Dispose()
        {
            _cursoRepository?.Dispose();
        }
    }
}