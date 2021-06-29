using FluentValidation;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.CursoValidation
{
    public class CursoDeleteValidation : AbstractValidator<Curso>
    {
        public CursoDeleteValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id não pode ser nulo");
        }
    }
}
