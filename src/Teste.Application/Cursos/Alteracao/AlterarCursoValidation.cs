using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Cursos.Alteracao
{
    public class AlterarCursoValidation : AbstractValidator<AlterarCursoCommand>
    {
        public AlterarCursoValidation()
        {
            _ = RuleFor(x => x.CursoId).Must(x => x.IsValidGuid()).WithMessage("Id do curso inválido!");
            _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome do curso!");
            _ = RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O nome do curso precisa ter até 200 caracteres!");
        }
    }
}
