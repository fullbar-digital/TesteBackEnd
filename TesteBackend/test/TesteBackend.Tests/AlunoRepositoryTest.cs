using System.Collections.Generic;
using Xunit;
using TesteBackend.Domain.Models;

namespace TesteBackend.Tests
{
    public class AlunoRepositoryTest
    {
        private readonly DatabaseInMemory databaseInMemory;

        public AlunoRepositoryTest()
        {
            this.databaseInMemory = new DatabaseInMemory();
        }
        
        [Fact]
        public void CadastrarNovoAluno()
        {
            Aluno alunoNovo = PreencherCadastroDeAluno();

            // Act
            var alunoSalvo = this.databaseInMemory.AlunoRepository.Add(alunoNovo);

            // Assert
            Assert.Equal(alunoNovo.Nome, alunoSalvo.Nome);
            Assert.Equal(alunoNovo.Matricula.Count, alunoSalvo.Matricula.Count);
            Assert.Equal(alunoNovo.Curso, alunoSalvo.Curso);
        }

        [Fact]
        public void ObterAlunoDoRepositorio()
        {
            // Arranje
            Aluno alunoNovo = this.databaseInMemory.AlunoRepository.Add(PreencherCadastroDeAluno());

            // Act
            Aluno alunoDb = this.databaseInMemory.AlunoRepository.Get(alunoNovo.Ra);

            // Assert
            Assert.Equal(alunoNovo.Ra, alunoDb.Ra);
        }

        private Aluno PreencherCadastroDeAluno()
        {
            Curso curso = this.databaseInMemory.CursoRepository.Add(new Curso("Física"));

            for (int i = 1; i <= 3; i++)
            {
                this.databaseInMemory.DisciplinaRepository.Add(new Disciplina($"Disciplina {i}", curso));
            }

            Curso cursoDb = this.databaseInMemory.CursoRepository.Get(curso.Id);

            Aluno aluno = new Aluno(nome: "Zé", periodo: 1, cursoDb, foto: "http://google.com", new List<Matricula>());

            foreach (var disciplina in cursoDb.Disciplinas)
            {
                aluno.Matricula.Add(new Matricula(aluno, disciplina, 9.0m));
            }

            //return this.databaseInMemory.AlunoRepository.Add(aluno);
            return aluno;
        }

    }
}
