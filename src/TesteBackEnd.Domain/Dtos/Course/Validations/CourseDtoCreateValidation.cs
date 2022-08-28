using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TesteBackEnd.Domain.Dtos.Course.Validations
{
    public class CourseDtoCreateValidation : AbstractValidator<CourseDtoCreate>
    {
        public CourseDtoCreateValidation()
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
