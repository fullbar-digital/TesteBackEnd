using FluentValidation;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.AlunoValidation
{
    public class AlunoDeleteValidation : AbstractValidator<Aluno>
    {
        public AlunoDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id não pode ser nulo");
        }
    }
}
