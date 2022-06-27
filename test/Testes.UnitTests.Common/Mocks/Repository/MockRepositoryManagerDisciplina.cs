using Moq;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Disciplinas.Entities;

namespace Testes.UnitTests.Common.Mocks.Repository
{
    public class MockRepositoryManagerDisciplina : Mock<IRepositoryManager>
    {
        public MockRepositoryManagerDisciplina ComUnitOfWork()
        {
            Setup(x => x.SaveAsync(default));
            return this;
        }

        public void VerificarUnitOfWork(Func<Times> times)
        {
            Verify(x => x.SaveAsync(default), times);
        }

        public MockRepositoryManagerDisciplina ComInserirDisciplina()
        {
            Setup(x => x.DisciplinaRepository.Inserir(It.IsAny<Disciplina>())).Returns(Guid.NewGuid());
            return this;
        }

        public void VerificarInserirDisciplina(Func<Times> times)
        {
            Verify(x => x.DisciplinaRepository.Inserir(It.IsAny<Disciplina>()),times);
        }

        public MockRepositoryManagerDisciplina ComAlterarDisciplina()
        {
            Setup(x => x.DisciplinaRepository.Alterar(It.IsAny<Disciplina>()));
            return this;
        }

        public void VerificarAlterarDisciplina(Func<Times> times)
        {
            Verify(x => x.DisciplinaRepository.Alterar(It.IsAny<Disciplina>()), times);
        }

        public MockRepositoryManagerDisciplina ComRemoverDisciplina()
        {
            Setup(x => x.DisciplinaRepository.Remover(It.IsAny<Guid>()));
            return this;
        }

        public void VerificarRemoverDisciplina(Func<Times> times)
        {
            Verify(x => x.DisciplinaRepository.Remover(It.IsAny<Guid>()), times);
        }
    }
}
