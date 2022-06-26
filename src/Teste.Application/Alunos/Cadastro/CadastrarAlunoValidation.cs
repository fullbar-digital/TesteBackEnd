using FluentValidation;
using Teste.Domain.Utils;

namespace Teste.Application.Alunos.Cadastro
{
    public class CadastrarAlunoValidation : AbstractValidator<CadastrarAlunoCommand>
    {
        public CadastrarAlunoValidation()
        {
            _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o nome do aluno!");
            _ = RuleFor(x => x.Nome).MaximumLength(200).WithMessage("O nome do aluno precisa ter até 200 caracteres!");
            _ = RuleFor(x => x.RegistroAcademico).NotEmpty().WithMessage("Informe o registro acadêmico do aluno!");
            _ = RuleFor(x => x.RegistroAcademico).MaximumLength(200).WithMessage("O registro acadêmico do aluno precisa ter até 200 caracteres!");
            _ = RuleFor(x => x.Periodo).GreaterThan(0).WithMessage("A o período do aluno precisa ser maior que 0!");
            _ = RuleFor(x => x.CursoId).Must(x => x.IsValidGuid()).WithMessage("Id do curso inválido!");
        }
    }
}
