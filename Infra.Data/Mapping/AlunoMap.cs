using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(o => o.Id);

            builder.HasIndex(o => o.Ra)
                .IsUnique();

            builder.Property(o => o.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Ra)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(o => o.Curso)
                .WithMany(o => o.Alunos)
                .HasForeignKey(o => o.CursoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}