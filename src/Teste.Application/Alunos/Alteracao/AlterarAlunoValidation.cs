using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Alunos.Alteracao
{
    public class AlterarAlunoValidation : AbstractValidator<AlterarAlunoCommand>
    {
        public AlterarAlunoValidation()
        {
            _ = RuleFor(x => x.Id).Must(x => x.IsValidGuid()).WithMessage("Id do aluno inválido!");
            _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome do aluno!");
            _ = RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O nome do aluno precisa ter até 200 caracteres!");
            _ = RuleFor(x => x.RegistroAcademico).NotEmpty().WithMessage("Informe o registro acadêmico do aluno!");
            _ = RuleFor(x => x.RegistroAcademico).MaximumLength(200).WithMessage("O registro acadêmico do aluno precisa ter até 200 caracteres!");
            _ = RuleFor(x => x.Periodo).GreaterThan(0).WithMessage("O período do aluno precisa ser maior que 0!");
            _ = RuleFor(x => x.CursoId).Must(x => x.IsValidGuid()).WithMessage("Id do curso inválido!");
        }
    }
}
