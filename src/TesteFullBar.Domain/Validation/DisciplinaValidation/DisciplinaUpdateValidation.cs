using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.DisciplinaValidation
{
    public class DisciplinaUpdateValidation : AbstractValidator<Disciplina>
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaUpdateValidation(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("Nome da disciplina não pode ser nulo");

            RuleFor(x => x)
                .MustAsync(ValidationDescricao)
                .WithMessage("Disciplina já cadastrado na base de dados");

        }

        private async Task<bool> ValidationDescricao(Disciplina disciplina, CancellationToken cancellationToken)
        {
            var disciplinaRepository = await _disciplinaRepository.GetByDescricaoAsync(disciplina.Descricao);

            return (disciplinaRepository?.Id) == disciplina.Id;
        }
    }
}
