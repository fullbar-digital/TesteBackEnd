using Bogus;
using Teste.Application.Disciplinas.Alteracao;

namespace Testes.UnitTests.Common.Fakers.Disciplina
{
    public class AlterarDisciplinaCommandFaker : Faker<AlterarDisciplinaCommand>
    {
        public AlterarDisciplinaCommandFaker()
        {
            RuleFor(x => x.Id, Guid.NewGuid().ToString());
            RuleFor(x => x.Nome, f => f.Name.JobDescriptor());
            RuleFor(x => x.NotaMinimaAprovacao, f => f.Random.Decimal(1, 10));
            RuleFor(x => x.CursoId, Guid.NewGuid().ToString());
        }
    }
}