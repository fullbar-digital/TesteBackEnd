using Moq;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Cursos.Entitites;

namespace Testes.UnitTests.Common.Mocks.Repository
{
    public class MockRepositoryManagerCurso : Mock<IRepositoryManager>
    {
        public MockRepositoryManagerCurso ComUnitOfWork()
        {
            Setup(x => x.SaveAsync(default));
            return this;
        }

        public void VerificarUnitOfWork(Func<Times> times)
        {
            Verify(x => x.SaveAsync(default), times);
        }

        public MockRepositoryManagerCurso ComInserirCurso()
        {
            Setup(x => x.CursoRepository.Inserir(It.IsAny<Curso>())).Returns(Guid.NewGuid());
            return this;
        }

        public void VerificarInserirCurso(Func<Times> times)
        {
            Verify(x => x.CursoRepository.Inserir(It.IsAny<Curso>()),times);
        }

        public MockRepositoryManagerCurso ComAlterarCurso()
        {
            Setup(x => x.CursoRepository.Alterar(It.IsAny<Curso>()));
            return this;
        }

        public void VerificarAlterarCurso(Func<Times> times)
        {
            Verify(x => x.CursoRepository.Alterar(It.IsAny<Curso>()), times);
        }

        public MockRepositoryManagerCurso ComRemoverCurso()
        {
            Setup(x => x.CursoRepository.Remover(It.IsAny<Guid>()));
            return this;
        }

        public void VerificarRemoverCurso(Func<Times> times)
        {
            Verify(x => x.CursoRepository.Remover(It.IsAny<Guid>()), times);
        }
    }
}
