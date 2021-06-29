using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.CursoValidation
{
    public class CursoUpdateValidation : AbstractValidator<Curso>
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoUpdateValidation(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("Nome do curso não pode ser nulo");

            RuleFor(x => x)
                .MustAsync(ValidationDescricao)
                .WithMessage("Curso já cadastrado na base de dados");

        }

        private async Task<bool> ValidationDescricao(Curso curso, CancellationToken cancellationToken)
        {
            var cursoRepository = await _cursoRepository.GetByDescricaoAsync(curso.Descricao);

            return (cursoRepository?.Id) == curso.Id;
        }
    }
}
