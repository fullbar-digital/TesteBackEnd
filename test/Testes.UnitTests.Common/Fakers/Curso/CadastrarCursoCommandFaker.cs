using Bogus;
using Teste.Application.Cursos.Cadastro;

namespace Testes.UnitTests.Common.Fakers.Curso
{
    public class CadastrarCursoCommandFaker : Faker<CadastrarCursoCommand>
    {
        public CadastrarCursoCommandFaker()
        {
            RuleFor(x => x.Nome, f => f.Name.JobArea());
        }
    }
}