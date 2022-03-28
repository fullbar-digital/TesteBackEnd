using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfigs
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {

        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(a => a.Nome)
                .HasMaxLength(200)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(a => a.RA)
                .IsRequired();

            builder.Property(a => a.Periodo)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasMaxLength(100)
                .HasColumnType("varchar(max)")
                .IsRequired();


            #region RELACIONAMENTOS

            builder.HasMany(a => a.Disciplinas)
                .WithOne(ad => ad.Aluno)
                .IsRequired()
                .HasForeignKey(ca => ca.DisciplinaID);

            #endregion

            builder.ToTable("Alunos");
            }
        }
}
