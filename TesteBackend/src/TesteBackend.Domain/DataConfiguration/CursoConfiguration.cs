using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.DataConfiguration
{
    internal class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
            => builder
                 .Property(c => c.Nome)
                 .HasColumnType("varchar")
                 .HasMaxLength(100)
                 .IsRequired();
    }
}
