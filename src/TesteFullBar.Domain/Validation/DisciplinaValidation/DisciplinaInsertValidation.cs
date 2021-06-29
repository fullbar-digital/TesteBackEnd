using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.DisciplinaValidation
{
    public class DisciplinaInsertValidation : AbstractValidator<Disciplina>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaInsertValidation(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("Nome da Disciplina não pode ser nulo");

            RuleFor(x => x)
                .MustAsync(ValidationDescricao)
                .WithMessage("Disciplina já cadastrado na base de dados");

        }

        private async Task<bool> ValidationDescricao(Disciplina disciplina, CancellationToken cancellationToken)
        {
            var disciplinaRepository = await _disciplinaRepository.GetByDescricaoAsync(disciplina.Descricao);

            return disciplina.Descricao != disciplinaRepository?.Descricao;
        }
    }
}
