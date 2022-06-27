using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Cursos.Remocao
{
    public class RemoverCursoValidation : AbstractValidator<RemoverCursoCommand>
    {
        public RemoverCursoValidation()
        {
            _ = RuleFor(x => x.Id).Must(x => x.IsValidGuid()).WithMessage("Id do curso inválido!");
        }
    }
}
