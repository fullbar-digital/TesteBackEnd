using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Infra.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.RA)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Periodo)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FotoNome)
                .HasColumnType("VARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Foto)
                .HasColumnType("varbinary(MAX)")               
                .IsRequired(false);

            builder.HasMany(x => x.AlunoDisciplinas)
                .WithOne(n => n.Aluno)
                .HasForeignKey(n => n.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
