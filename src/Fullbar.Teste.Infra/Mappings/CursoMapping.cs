using Fullbar.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fullbar.Teste.Infra.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasMany(c => c.Disciplinas)
               .WithOne(d => d.Curso)
               .HasForeignKey(d => d.CursoId);

            builder.HasMany(c => c.Alunos)
              .WithOne(d => d.Curso)
              .HasForeignKey(d => d.CursoId);

            builder.ToTable("Disciplinas");
        }
    }
}