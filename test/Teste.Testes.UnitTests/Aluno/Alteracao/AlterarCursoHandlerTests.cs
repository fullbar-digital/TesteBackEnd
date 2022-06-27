using Moq;
using Teste.Application.Alunos.Alteracao;
using Testes.UnitTests.Common.Fakers.Aluno;
using Testes.UnitTests.Common.Mocks.Mapper;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Aluno.Alteracao
{
    public class AlterarAlunoHandlerTests
    {
        [Fact]
        public void Teste_Alterar_Aluno_OK()
        {
            var alterarAlunoCommand = new AlterarAlunoCommandFaker().Generate();
            var mockRepository = new MockRepositoryManagerAluno().ComAlterarAluno()
                                                            .ComUnitOfWork();
            var mapper = new MockMapper().Mapper;

            var alterarAlunoHandle = new AlterarAlunoCommandHandler(mockRepository.Object, mapper);

            var result = alterarAlunoHandle.Handle(alterarAlunoCommand, default);

            mockRepository.VerificarAlterarAluno(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
