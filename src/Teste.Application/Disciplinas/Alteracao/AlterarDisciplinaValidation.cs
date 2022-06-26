using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Disciplinas.Alteracao
{
    public class AlterarDisciplinaValidation : AbstractValidator<AlterarDisciplinaCommand>
    {
        public AlterarDisciplinaValidation()
        {
            _ = RuleFor(x => x.Id).Must(x => x.IsValidGuid()).WithMessage("Id da disciplina inválido!");
            _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome da disciplina!");
            _ = RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O nome da disciplina precisa ter até 200 caracteres!");
            _ = RuleFor(x => x.NotaMinimaAprovacao).GreaterThan(0).WithMessage("A nota minima de aprovação precisa ser maior que 0!");            
        }
    }
}
