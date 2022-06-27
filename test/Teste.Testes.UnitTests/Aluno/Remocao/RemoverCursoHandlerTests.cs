using Moq;
using Teste.Application.Alunos.Remocao;
using Testes.UnitTests.Common.Mocks.Repository;

namespace Teste.UnitTests.Aluno.Remocao
{
    public class RemoverAlunoHandlerTests
    {
        [Fact]
        public void Teste_Remover_Aluno_OK()
        {
            var removerAlunoCommand = new RemoverAlunoCommand()
            {
                Id = Guid.NewGuid().ToString()
            };

            var mockRepository = new MockRepositoryManagerAluno().ComRemoverAluno()
                                                            .ComUnitOfWork();            

            var removerAlunoHandle = new RemoverAlunoCommandHandler(mockRepository.Object);

            var result = removerAlunoHandle.Handle(removerAlunoCommand, default);

            mockRepository.VerificarRemoverAluno(Times.Once);
            mockRepository.VerificarUnitOfWork(Times.Once);
        }
    }
}
