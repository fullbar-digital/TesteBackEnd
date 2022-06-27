using Moq;
using Teste.Application.Cursos.Remocao;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Curso.Remocao
{
    public class RemoverCursoHandlerTests
    {
        [Fact]
        public void Teste_Remover_Curso_OK()
        {
            var removerCursoCommand = new RemoverCursoCommand()
            {
                Id = Guid.NewGuid().ToString()
            };

            var mockRepository = new MockRepositoryManagerCurso().ComRemoverCurso()
                                                            .ComUnitOfWork();            

            var removerCursoHandle = new RemoverCursoCommandHandler(mockRepository.Object);

            var result = removerCursoHandle.Handle(removerCursoCommand, default);

            mockRepository.VerificarRemoverCurso(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
