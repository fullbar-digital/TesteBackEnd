using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class DisiciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplina");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.NotaMinima);
        }
    }
}