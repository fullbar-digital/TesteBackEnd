using FluentValidation;

namespace Fullbar.Teste.Domain.Entities.Validation
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}