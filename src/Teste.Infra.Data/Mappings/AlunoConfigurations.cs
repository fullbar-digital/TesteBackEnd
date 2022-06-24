
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Alunos.Entities;

namespace Teste.Infra.Data.Mappings
{
    public class AlunoConfigurations : BaseEntityConfiguration<Aluno>
    {
        public override void ConfigureProperties(EntityTypeBuilder<Aluno> builder)
        {
            Configure(builder);

            _ = builder.ToTable("TB_ALUNO");
            _ = builder.Property(x => x.Nome).HasMaxLength(200).HasColumnName("NOME");
            _ = builder.Property(x => x.RA).HasMaxLength(100).HasColumnName("REGISTRO_ACADEMICO");
            _ = builder.Property(x => x.Periodo).HasColumnName("PERIODO");
            _ = builder.HasOne(x => x.Curso).WithMany(x => x.Alunos).HasForeignKey(x => x.CursoId).HasConstraintName("FK_ALUNO_CURSO");
            _ = builder.Property(x => x.Status).HasColumnName("STATUS");
            _ = builder.Property(x => x.Foto).HasColumnName("FOTO");
        }
    }
}

