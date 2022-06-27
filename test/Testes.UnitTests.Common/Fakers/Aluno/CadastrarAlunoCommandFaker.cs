using Bogus;
using Teste.Application.Alunos.Cadastro;

namespace Testes.UnitTests.Common.Fakers.Aluno
{
    public class CadastrarAlunoCommandFaker : Faker<CadastrarAlunoCommand>
    {
        public CadastrarAlunoCommandFaker()
        {
            RuleFor(x => x.Nome, f => f.Name.JobArea());
            RuleFor(x => x.RegistroAcademico, f => f.Person.Random.Digits(1,3,9)[0].ToString());
            RuleFor(x => x.CursoId, Guid.NewGuid().ToString());
            RuleFor(x => x.Foto, f => f.Person.Avatar);
        }
    }
}