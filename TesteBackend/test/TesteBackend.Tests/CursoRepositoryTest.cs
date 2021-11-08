using System;
using Xunit;
using TesteBackend.Domain.Models;

namespace TesteBackend.Tests
{
    public class CursoRepositoryTest
    {
        private readonly DatabaseInMemory databaseInMemory;

        public CursoRepositoryTest()
        {
            this.databaseInMemory = new DatabaseInMemory();
        }

        #region Cadastrar novo Curso no repositório
        [Fact]
        public void CadastrarNovoCurso()
        {
            // Arrange
            Curso curso = new Curso("Matemática");

            // Act
            Curso cursoDb = this.databaseInMemory.CursoRepository.Add(curso);

            // Assert
            Assert.Equal(curso, cursoDb);
        }

        [Fact]
        public void CadastrarCursoSemNome()
        {
            // Arrange
            Curso curso = new Curso("");

            // Assert
            Assert.Throws<ArgumentNullException>(
                    // Act    
                    () => this.databaseInMemory.CursoRepository.Add(curso)
                );
        }
        #endregion

        #region Obter curso do repositório
        [Fact]
        public void ObterCurso()
        {
            // Arrange
            int cursoId = 1;

            // Act
            Curso cursoDb = this.databaseInMemory.CursoRepository.Get(cursoId);

            // Assert
            Assert.NotNull(cursoDb);
        }
        #endregion

        #region Alterar curso
        [Fact]
        public void AlterarNomeDoCurso()
        {
            // Arrange
            int cursoId = 1;
            Curso cursoDb = this.databaseInMemory.CursoRepository.Get(cursoId);

            string novoNomeDoCurso = "Novo nome do curso";
            cursoDb.Nome = novoNomeDoCurso;

            // Act
            Curso cursoAlterado = this.databaseInMemory.CursoRepository.Edit(cursoDb);

            // Assert
            Assert.Equal(novoNomeDoCurso, cursoAlterado.Nome);
        } 
        #endregion

        [Fact]
        public void ExcluirCurso()
        {
            // Arrange
            Curso cursoDb = this.databaseInMemory.CursoRepository.Add(new Curso("Curso Test"));
            var cursoId = cursoDb.Id;

            // Act
            this.databaseInMemory.CursoRepository.Delete(cursoId);

            // Assert
            Assert.Null(this.databaseInMemory.CursoRepository.Get(cursoId));
        }


    }
}
