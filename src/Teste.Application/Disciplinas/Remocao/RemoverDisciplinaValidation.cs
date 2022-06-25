using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Disciplinas.Remocao
{
    public class RemoverDisciplinaValidation : AbstractValidator<RemoverDisciplinaCommand>
    {
        public RemoverDisciplinaValidation()
        {
            _ = RuleFor(x => x.DisciplinaId).Must(x => x.IsValidGuid()).WithMessage("Id da disciplina inválido!");
        }
    }
}
