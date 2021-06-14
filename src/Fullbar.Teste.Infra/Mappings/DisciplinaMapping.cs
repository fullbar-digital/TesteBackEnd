using Fullbar.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fullbar.Teste.Infra.Mappings
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.NotaMinima)
               .IsRequired()
               .HasColumnType("decimal(15,2)");

            builder.ToTable("Disciplinas");
        }
    }
}