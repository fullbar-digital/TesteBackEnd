
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Cursos.Entitites;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Infra.Data.Mappings
{
    public class CursoConfigurations : BaseEntityConfiguration<Curso>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Curso> builder)
        {
            Configure(builder);

            _ = builder.ToTable("TB_CURSO");
            _ = builder.Property(x => x.Nome).HasMaxLength(200).HasColumnName("NOME");
            _ = builder.HasMany(x => x.Disciplinas).WithOne(x => x.Curso).HasForeignKey(x => x.CursoId).HasConstraintName("FK_CURSO_DISCIPLINA");
        }
    }
}
