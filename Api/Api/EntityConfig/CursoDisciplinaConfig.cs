using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfigs
{
    public class CursoDisciplinaConfig : IEntityTypeConfiguration<CursoDisciplina>
    {
        public void Configure(EntityTypeBuilder<CursoDisciplina> builder)
        {
            #region RELACIONAMENTOS

            builder.HasOne(c => c.Curso)
                 .WithMany(d => d.Disciplinas)
                 .HasForeignKey(c => c.CursoID);


            #endregion

            builder.ToTable("CursosDisciplinas");
        }
    }
}
