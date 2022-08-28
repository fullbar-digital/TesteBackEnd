using FluentValidation;

namespace TesteBackEnd.Domain.Dtos.Course.Validations
{
    public class CourseDtoUpdateValidation : AbstractValidator<CourseDtoUpdate>
    {
        public CourseDtoUpdateValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(p => p.Name)
              .MaximumLength(150)
              .WithMessage("O campo {PropertyName} não pode ser maior que {MaxLength}.");
        }
    }
}
