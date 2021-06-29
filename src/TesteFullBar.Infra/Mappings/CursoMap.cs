using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Infra.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder.HasMany(n => n.Disciplinas)
                .WithOne(n => n.Curso)
                .HasForeignKey(n => n.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(n => n.Alunos)
                .WithOne(n => n.Curso)
                .HasForeignKey(n => n.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
