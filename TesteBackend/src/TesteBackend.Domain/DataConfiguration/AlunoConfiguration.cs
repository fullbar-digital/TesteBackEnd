using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.DataConfiguration
{
    internal class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder
                .Property(a => a.Ra)
                .IsRequired();

            builder
                .HasKey(a => a.Ra);

            builder
                .Property(a => a.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(a => a.Periodo)
                .IsRequired();
        }
    }
}
