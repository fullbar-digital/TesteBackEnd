using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfigs
{
    public class AlunoDisciplinaConfig : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.Property(a => a.Nota)
                .IsRequired();

            #region RELACIONAMENTOS

            builder.HasOne(aa => aa.Aluno)
                .WithMany(a => a.Disciplinas)
                .HasForeignKey(aa => aa.AlunoID);

            #endregion

            builder.ToTable("AlunoDisciplinas");
        }
    }
}
