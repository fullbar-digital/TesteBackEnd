using Moq;
using Teste.Application.Disciplinas.Alteracao;
using Testes.UnitTests.Common.Fakers.Disciplina;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Disciplina.Alteracao
{
    public class AlterarDisciplinaHandlerTests
    {
        [Fact]
        public void Teste_Alterar_Disciplina_OK()
        {
            var alterarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerDisciplina().ComAlterarDisciplina()
                                                            .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var alterarDisciplinaHandle = new AlterarDisciplinaCommandHandler(mockRepository.Object, mapper);

            var result = alterarDisciplinaHandle.Handle(alterarDisciplinaCommand, default);

            mockRepository.VerificarAlterarDisciplina(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
