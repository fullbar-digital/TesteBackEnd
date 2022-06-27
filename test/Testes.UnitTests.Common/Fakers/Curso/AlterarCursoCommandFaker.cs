using Bogus;
using Teste.Application.Cursos.Alteracao;

namespace Testes.UnitTests.Common.Fakers.Curso
{
    public class AlterarCursoCommandFaker : Faker<AlterarCursoCommand>
    {
        public AlterarCursoCommandFaker()
        {
            RuleFor(x => x.CursoId, f => Guid.NewGuid().ToString());
            RuleFor(x => x.Nome, f => f.Name.JobArea());
        }
    }
}