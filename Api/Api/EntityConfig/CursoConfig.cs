using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfigs
{
    public class CursoConfig : IEntityTypeConfiguration<Curso>
    {

        public void Configure(EntityTypeBuilder<Curso> builder)
        {

            builder.Property(a => a.Nome)
                .HasMaxLength(200)
                .HasColumnType("varchar(max)")
                .IsRequired();

            #region RELACIONAMENTOS

            builder.HasMany(a => a.Disciplinas)
                .WithOne(ad => ad.Curso)
                .IsRequired()
                .HasForeignKey(ca => ca.CursoID);
            #endregion

            builder.ToTable("Curso");
        }
    }
}
