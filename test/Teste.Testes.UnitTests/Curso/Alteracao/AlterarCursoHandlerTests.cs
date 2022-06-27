using Moq;
using Teste.Application.Cursos.Alteracao;
using Testes.UnitTests.Common.Fakers;
using Testes.UnitTests.Common.Fakers.Curso;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Curso.Alteracao
{
    public class AlterarCursoHandlerTests
    {
        [Fact]
        public void Teste_Alterar_Curso_OK()
        {
            var alterarCursoCommand = new AlterarCursoCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerCurso().ComAlterarCurso()
                                                            .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var alterarCursoHandle = new AlterarCursoCommandHandler(mockRepository.Object, mapper);

            var result = alterarCursoHandle.Handle(alterarCursoCommand, default);

            mockRepository.VerificarAlterarCurso(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
