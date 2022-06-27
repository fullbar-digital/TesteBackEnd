using Moq;
using Teste.Application.Alunos.Cadastro;
using Testes.UnitTests.Common.Fakers.Aluno;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Aluno.Cadastro
{
    public class CadastrarAlunoHandlerTests
    {
        [Fact]
        public void Teste_Cadastrar_Aluno_OK()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerAluno().ComInserirAluno()
                                                            .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var cadastrarAlunoHandle = new CadastrarAlunoCommandHandler(mockRepository.Object, mapper);

            var result = cadastrarAlunoHandle.Handle(cadastrarAlunoCommand, default);

            Assert.NotEmpty(result.Result.Id);

            mockRepository.VerificarInserirAluno(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
