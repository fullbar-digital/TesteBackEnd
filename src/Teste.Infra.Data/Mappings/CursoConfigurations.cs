
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Cursos.Entitites;

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

            _ = builder.HasData(
                    new Curso { Id = new Guid("47638E27-2992-4021-BD4C-9D3DDBBAB597"), Nome = "CURSO 001" },
                    new Curso { Id = new Guid("36F5EC76-D5A5-4EFF-949B-2FE44DAD5A0E"), Nome = "CURSO 002" }
                );
        }
    }
}
