using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}