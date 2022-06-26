using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Alunos.Remocao
{
    public class RemoverAlunoValidation : AbstractValidator<RemoverAlunoCommand>
    {
        public RemoverAlunoValidation()
        {
            _ = RuleFor(x => x.Id).Must(x => x.IsValidGuid()).WithMessage("Id do aluno inválido!");
        }
    }
}
