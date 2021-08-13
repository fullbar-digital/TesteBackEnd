using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dados
{
    public class CadastroContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Diciplina> Diciplinas { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        public CadastroContext(DbContextOptions options) : base(options)
        {
        }
    }
}
