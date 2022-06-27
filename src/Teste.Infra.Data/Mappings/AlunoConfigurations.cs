
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
            _ = builder.HasOne(x => x.Curso).WithMany(x => x.Alunos).HasConstraintName("FK_ALUNO_CURSO");
            _ = builder.Property(x => x.CursoId).HasColumnName("CURSO_ID");
            _ = builder.Property(x => x.Status).HasColumnName("STATUS");
            _ = builder.Property(x => x.Foto).HasColumnName("FOTO");

            _ = builder.HasData(
                new Aluno { CursoId = new Guid("47638E27-2992-4021-BD4C-9D3DDBBAB597"), Nome = "Garry Kasparov", Periodo = 8, Foto = "https://i1.wp.com/dailychessmusings.com/wp-content/uploads/2020/04/bcf95-20130904_kasparov_0111_edit_1363-2.jpg?ssl=1", RA = "000101" },
                new Aluno { CursoId = new Guid("36F5EC76-D5A5-4EFF-949B-2FE44DAD5A0E"), Nome = "Magnus Carlsen", Periodo = 5, Foto = "https://norwaytoday.info/wp-content/uploads/2020/10/Magnus-Carlsen-Heiko-Junge-NTB-1.jpg", RA = "000102" }
            );
        }
    }
}

