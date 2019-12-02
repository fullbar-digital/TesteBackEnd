using BancoAlunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoAlunos.Data.DataModels
{
    public class AlunosDataModel : IEntityTypeConfiguration<Alunos>
    {
        //Mapeamento Base de Dados

        #region ConfigureBuilders
        public void Configure(EntityTypeBuilder<Alunos> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(t => t.RA)
                    .HasMaxLength(8)
                    .IsRequired();

            builder.Property(t => t.Periodo)
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(t => t.Curso)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(t => t.Nota)
                    .HasMaxLength(4)
                    .IsRequired()
                    .HasColumnType("Decimal(4,2)");

            builder.ToTable("Alunos");

        }
        #endregion
    }
}
