
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Infra.Data.Mappings
{
    public class DisciplinaConfigurations : BaseEntityConfiguration<Disciplina>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Disciplina> builder)
        {
            Configure(builder);

            _ = builder.ToTable("TB_DISCIPLINA");
            _ = builder.Property(x => x.Nome).HasMaxLength(200).HasColumnName("NOME");
            _ = builder.Property(x => x.NotaMinimaAprovacao).HasColumnType("decimal(10,2)").HasColumnName("NOTA_MINIMA_APROVACAO");
            _ = builder.Property(x => x.CursoId).HasColumnName("CURSO_ID");

        }
    }
}
