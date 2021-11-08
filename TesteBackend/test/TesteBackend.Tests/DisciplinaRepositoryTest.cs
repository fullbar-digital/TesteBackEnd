using System;
using System.Collections.Generic;
using Xunit;
using TesteBackend.Domain.Models;

namespace TesteBackend.Tests
{
    public class DisciplinaRepositoryTest
    {
        private readonly DatabaseInMemory databaseInMemory;

        public DisciplinaRepositoryTest()
        {
            this.databaseInMemory = new DatabaseInMemory();
        }

        [Fact]
        public void CadastrarNovaDisciplina()
        {
            // Arrange
            Curso cursoNovo = new Curso("Física");
            this.databaseInMemory.CursoRepository.Add(cursoNovo);
            Disciplina disciplinaNova = new Disciplina("Matemática", cursoNovo);

            // Act
            Disciplina  disciplina = this.databaseInMemory.DisciplinaRepository.Add(disciplinaNova);

            // Assert
            Assert.Equal(disciplinaNova.Id, disciplina.Id);
            Assert.Equal(disciplinaNova.Nome, disciplina.Nome);
        }

        [Fact]
        public void CadastrarNovaDisciplinaEmCursoComAlunosMatriculados()
        {
            // Arrange
            Curso curso = new Curso("Física");
            var cursodb = this.databaseInMemory.CursoRepository.Add(curso);

            Disciplina disciplina = new Disciplina("Física I", curso);
            this.databaseInMemory.DisciplinaRepository.Add(disciplina);
            
            Aluno alunoNovo = new Aluno(nome: "Aluno 1",
                                        periodo: 1,
                                        curso: curso,
                                        foto: "http://meusite.com/foto.jpg",
                                        matriculas: new List<Matricula>());

            foreach (var disciplinaCurso in curso.Disciplinas)
            {
                var matricula = new Matricula(aluno: alunoNovo, disciplina: disciplinaCurso, nota: 8.0m);
                alunoNovo.Matricula.Add(matricula);
            }

            this.databaseInMemory.AlunoRepository.Add(alunoNovo);
            
            Disciplina novaDisciplina = new Disciplina("Disciplina teste", curso);
            
            // Assert
            Assert.Throws<OperationCanceledException>(
                // Act    
                () => this.databaseInMemory.DisciplinaRepository.Add(novaDisciplina)
            );
        }

        [Fact]
        public void ObterDisciplinaDoRepositorio()
        {
            // Arrange
            Curso curso = new Curso("Física");
            this.databaseInMemory.CursoRepository.Add(curso);

            Disciplina disciplina = new Disciplina("Física I", curso);
            this.databaseInMemory.DisciplinaRepository.Add(disciplina);

            // Act
            Disciplina disciplinaDb = this.databaseInMemory.DisciplinaRepository.Get(disciplina.Id);

            // Assert
            Assert.Equal(disciplina, disciplinaDb);
        }

        [Fact]
        public void ExcluirDisciplina()
        {
            // Arranje
            Curso curso = new Curso("Física");
            this.databaseInMemory.CursoRepository.Add(curso);

            Disciplina disciplina = new Disciplina("Física I", curso);
            this.databaseInMemory.DisciplinaRepository.Add(disciplina);

            Disciplina disciplinaDb = this.databaseInMemory.DisciplinaRepository.Get(disciplina.Id);

            // Act
            this.databaseInMemory.DisciplinaRepository.Delete(disciplinaDb.Id);

            Disciplina disciplinaCheckDeleted = this.databaseInMemory.DisciplinaRepository.Get(disciplina.Id);

            // Assert
            Assert.Null(disciplinaCheckDeleted);
        }

    }
}
