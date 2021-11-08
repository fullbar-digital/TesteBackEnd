using System;
using Xunit;
using Moq;
using TesteBackend.Domain;
using Microsoft.EntityFrameworkCore;
using TesteBackend.Domain.Repositories;

namespace TesteBackend.Tests
{
    /// <summary>
    /// Classe para gerenciar as instâncias dos repositórios utilizando DatabaseInMemory
    /// </summary>
    internal class DatabaseInMemory
    {
        private DbContextOptions options;
        private DbBackendContext context;

        /// <summary>
        /// Instância do repositório de Curso utilizando DatabaseInMemory
        /// </summary>
        internal ICursoRepository CursoRepository { get; set; }
        /// <summary>
        /// Instância do repositório de Disciplina utilizando DatabaseInMemory
        /// </summary>
        internal DisciplinaRepository DisciplinaRepository { get; set; }
        /// <summary>
        /// Instância do repositório de Alunos e Matrícula utilizando DatabaseInMemory
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
