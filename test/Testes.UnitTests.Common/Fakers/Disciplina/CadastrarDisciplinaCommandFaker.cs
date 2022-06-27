using Bogus;
using Teste.Application.Cursos.Cadastro;
using Teste.Application.Disciplinas.Cadastro;

namespace Testes.UnitTests.Common.Fakers.Disciplina
{
    public class CadastrarDisciplinaCommandFaker : Faker<CadastrarDisciplinaCommand>
    {
        public CadastrarDisciplinaCommandFaker()
        {
            RuleFor(x => x.Nome, f => f.Name.JobDescriptor());
            RuleFor(x => x.NotaMinimaAprovacao, f => f.Random.Decimal(1,10));
            RuleFor(x => x.CursoId, Guid.NewGuid().ToString());
        }
    }
}