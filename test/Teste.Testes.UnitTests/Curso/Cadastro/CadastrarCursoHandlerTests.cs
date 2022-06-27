using Moq;
using Teste.Application.Cursos.Cadastro;
using Testes.UnitTests.Common.Fakers.Curso;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Curso.Cadastro
{
    public class CadastrarCursoHandlerTests
    {
        [Fact]
        public void Teste_Cadastrar_Curso_OK()
        {
            var cadastrarCursoCommand = new CadastrarCursoCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerCurso().ComInserirCurso()
                                                            .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var cadastrarCursoHandle = new CadastrarCursoCommandHandler(mockRepository.Object, mapper);

            var result = cadastrarCursoHandle.Handle(cadastrarCursoCommand, default);

            Assert.NotEmpty(result.Result.Id);

            mockRepository.VerificarInserirCurso(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
