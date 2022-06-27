using Bogus;
using Teste.Application.Alunos.Alteracao;

namespace Testes.UnitTests.Common.Fakers.Aluno
{
    public class AlterarAlunoCommandFaker : Faker<AlterarAlunoCommand>
    {
        public AlterarAlunoCommandFaker()
        {
            RuleFor(x => x.Id, f => Guid.NewGuid().ToString());
            RuleFor(x => x.Nome, f => f.Name.JobArea());
            RuleFor(x => x.RegistroAcademico, f => f.Person.Random.Digits(1,3,9)[0].ToString());
            RuleFor(x => x.CursoId, Guid.NewGuid().ToString());
            RuleFor(x => x.Foto, f => f.Person.Avatar);

        }
    }
}