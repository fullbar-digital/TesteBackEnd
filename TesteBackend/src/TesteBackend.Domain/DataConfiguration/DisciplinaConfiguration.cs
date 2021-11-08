using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.DataConfiguration
{
    internal class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder
                .Property(d => d.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(d => d.NotaMinimaAprovacao)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
        }
    }
}
