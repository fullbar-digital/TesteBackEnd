using System;
using Xunit;
using Moq;
using TesteBackend.Domain;
using Microsoft.EntityFrameworkCore;
using TesteBackend.Domain.Repositories;

namespace TesteBackend.Tests
{
    /// <summary>
    /// Classe para gerenciar as inst�ncias dos reposit�rios utilizando DatabaseInMemory
    /// </summary>
    internal class DatabaseInMemory
    {
        private DbContextOptions options;
        private DbBackendContext context;

        /// <summary>
        /// Inst�ncia do reposit�rio de Curso utilizando DatabaseInMemory
        /// </summary>
        internal ICursoRepository CursoRepository { get; set; }
        /// <summary>
        /// Inst�ncia do reposit�rio de Disciplina utilizando DatabaseInMemory
        /// </summary>
        internal DisciplinaRepository DisciplinaRepository { get; set; }
        /// <summary>
        /// Inst�ncia do reposit�rio de Alunos e Matr�cula utilizando DatabaseInMemory
        /// </summary>
        internal AlunoRepository AlunoRepository { get; set; }

        internal DatabaseInMemory(string databaseName = "TesteBackendFullbarDb")
        {
            GetContext(databaseName);

            this.CursoRepository = new CursoRepository(context);
            this.DisciplinaRepository = new DisciplinaRepository(context);
            this.AlunoRepository = new AlunoRepository(context, this.CursoRepository);
        }

        private void GetContext(string databaseName)
        {
            this.options = new DbContextOptionsBuilder<DbBackendContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            this.context = new DbBackendContext(options);
        }
    }
}
