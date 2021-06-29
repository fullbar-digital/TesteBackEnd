using FluentValidation;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.DisciplinaValidation
{
    public class DisciplinaDeleteValidation : AbstractValidator<Disciplina>
    {
        public DisciplinaDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id não pode ser nulo");
        }
    }
}
