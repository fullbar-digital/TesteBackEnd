using Moq;
using Teste.Application.Disciplinas.Remocao;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Disciplina.Remocao
{
    public class RemoverDisciplinaHandlerTests
    {
        [Fact]
        public void Teste_Remover_Disciplina_OK()
        {
            var removerDisciplinaCommand = new RemoverDisciplinaCommand()
            {
                Id = Guid.NewGuid().ToString()
            };

            var mockRepository = new MockRepositoryManagerDisciplina().ComRemoverDisciplina()
                                                            .ComUnitOfWork();            

            var removerDisciplinaHandle = new RemoverDisciplinaCommandHandler(mockRepository.Object);

            var result = removerDisciplinaHandle.Handle(removerDisciplinaCommand, default);

            mockRepository.VerificarRemoverDisciplina(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
