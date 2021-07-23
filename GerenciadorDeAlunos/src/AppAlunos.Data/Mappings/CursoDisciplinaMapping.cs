using AppAlunos.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAlunos.Data.Mappings
{
    public class CursoDisciplinaMapping : IEntityTypeConfiguration<CursoDisciplina>
    {
        public void Configure(EntityTypeBuilder<CursoDisciplina> builder)
        {
            builder.HasKey(cd => new { cd.CursoId, cd.DisciplinaId });

            // N : N => Curso : Disciplinas
            builder.HasOne(c => c.Curso)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(c => c.CursoId);

            // N : N => Disciplinas : Curso
            builder.HasOne(d => d.Disciplina)
                .WithMany(cd => cd.CursosDisciplinas)
                .HasForeignKey(d => d.DisciplinaId);

            builder.ToTable("CursoDisciplina");

        }
    }
}