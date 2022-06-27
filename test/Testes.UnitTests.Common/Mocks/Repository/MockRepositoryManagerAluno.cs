using Moq;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Alunos.Entities;

namespace Testes.UnitTests.Common.Mocks.Repository
{
    public class MockRepositoryManagerAluno : Mock<IRepositoryManager>
    {
        public MockRepositoryManagerAluno ComUnitOfWork()
        {
            Setup(x => x.SaveAsync(default));
            return this;
        }

        public void VerificarUnitOfWork(Func<Times> times)
        {
            Verify(x => x.SaveAsync(default), times);
        }

        public MockRepositoryManagerAluno ComInserirAluno()
        {
            Setup(x => x.AlunoRepository.Inserir(It.IsAny<Aluno>())).Returns(Guid.NewGuid());
            return this;
        }

        public void VerificarInserirAluno(Func<Times> times)
        {
            Verify(x => x.AlunoRepository.Inserir(It.IsAny<Aluno>()),times);
        }

        public MockRepositoryManagerAluno ComAlterarAluno()
        {
            Setup(x => x.AlunoRepository.Alterar(It.IsAny<Aluno>()));
            return this;
        }

        public void VerificarAlterarAluno(Func<Times> times)
        {
            Verify(x => x.AlunoRepository.Alterar(It.IsAny<Aluno>()), times);
        }

        public MockRepositoryManagerAluno ComRemoverAluno()
        {
            Setup(x => x.AlunoRepository.Remover(It.IsAny<Guid>()));
            return this;
        }

        public void VerificarRemoverAluno(Func<Times> times)
        {
            Verify(x => x.AlunoRepository.Remover(It.IsAny<Guid>()), times);
        }
    }
}
