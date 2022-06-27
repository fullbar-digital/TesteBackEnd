using Moq;
using Teste.Application.Disciplinas.Cadastro;
using Testes.UnitTests.Common.Fakers.Disciplina;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Disciplina.Cadastro
{
    public class CadastrarDisciplinaHandlerTests
    {
        [Fact]
        public void Teste_Cadastrar_Disciplina_OK()
        {
            var cadastrarDisciplinaCommand = new CadastrarDisciplinaCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerDisciplina().ComInserirDisciplina()
                                                                      .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var cadastrarDisciplinaHandle = new CadastrarDisciplinaCommandHandler(mockRepository.Object, mapper);

            var result = cadastrarDisciplinaHandle.Handle(cadastrarDisciplinaCommand, default);

            Assert.NotEmpty(result.Result.Id);

            mockRepository.VerificarInserirDisciplina(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
