using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Domain.Entities.Validation;
using Fullbar.Teste.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace Fullbar.Teste.Application.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository,
                              INotificador notificador) : base(notificador)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task Adicionar(Aluno aluno)
        {
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            await _alunoRepository.Adicionar(aluno);
        }

        public async Task Atualizar(Aluno aluno)
        {
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            await _alunoRepository.Atualizar(aluno);
        }

        public async Task Remover(Guid id)
        {
            await _alunoRepository.Remover(id);
        }

        public async Task<Aluno> Obter(Aluno aluno)
        {
            return await _alunoRepository.Obter(aluno);
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
    }
}