using Fullbar.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fullbar.Teste.Infra.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.RA)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Periodo)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(p => p.Foto)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Status)
               .IsRequired()
               .HasColumnType("bit");

            builder.ToTable("Alunos");
        }
    }
}
