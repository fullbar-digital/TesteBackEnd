
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

            _ = builder.HasData(
                new Disciplina { CursoId = new Guid("47638E27-2992-4021-BD4C-9D3DDBBAB597"), Nome = "DISCIPLINA 001", NotaMinimaAprovacao = 7.00m },
                new Disciplina { CursoId = new Guid("47638E27-2992-4021-BD4C-9D3DDBBAB597"), Nome = "DISCIPLINA 002", NotaMinimaAprovacao = 6.00m },
                new Disciplina { CursoId = new Guid("47638E27-2992-4021-BD4C-9D3DDBBAB597"), Nome = "DISCIPLINA 003", NotaMinimaAprovacao = 8.00m },
                new Disciplina { CursoId = new Guid("36F5EC76-D5A5-4EFF-949B-2FE44DAD5A0E"), Nome = "DISCIPLINA 004", NotaMinimaAprovacao = 5.00m },
                new Disciplina { CursoId = new Guid("36F5EC76-D5A5-4EFF-949B-2FE44DAD5A0E"), Nome = "DISCIPLINA 005", NotaMinimaAprovacao = 9.00m },
                new Disciplina { CursoId = new Guid("36F5EC76-D5A5-4EFF-949B-2FE44DAD5A0E"), Nome = "DISCIPLINA 006", NotaMinimaAprovacao = 10.00m }
            );

        }
    }
}
