using Moq;
using Teste_BackEnd.Models;
using Teste_BackEnd.Repositories;
using Xunit;

namespace Teste_BackEnd.Tests
{
    public class DisciplinaRepositoryTests
    {
        [Fact]
        public void GetByNome_Sucesso()
        {
            // Assert
            string nome = "Teste";
            int cursoId = 1;

            var moq = new Mock<DisciplinaRepository>();
            moq.Setup(m => m.GetByNome(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new Disciplina());

            // Act
            DisciplinaRepository disciplinaRepository = new DisciplinaRepository();

            // Arrange
        }
    }
}
