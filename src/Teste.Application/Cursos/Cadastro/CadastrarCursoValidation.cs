using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Cursos.Cadastro
{
    public class CadastrarCursoValidation : AbstractValidator<CadastrarCursoCommand>
    {
        public CadastrarCursoValidation()
        {
            _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome do curso!");
            _ = RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O nome do curso precisa ter até 200 caracteres!");
        }
    }
}
