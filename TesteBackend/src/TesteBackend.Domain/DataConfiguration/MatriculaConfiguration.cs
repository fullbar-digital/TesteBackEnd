using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.DataConfiguration
{
    internal class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder
                .HasKey(m => new { m.AlunoRa, m.DisciplinaId});

            builder
                .Property(m => m.Nota)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
        }
    }
}
