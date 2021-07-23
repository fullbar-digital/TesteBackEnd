using AppAlunos.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAlunos.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(a => a.RegistroAcademico)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Periodo)
                .IsRequired()
                .HasColumnType("varchar(8)");

            // N : 1 => Aluno : Curso
            builder.HasOne(a => a.Curso)
                .WithMany(c => c.Alunos);

            builder.ToTable("Alunos");
        }
    }
}