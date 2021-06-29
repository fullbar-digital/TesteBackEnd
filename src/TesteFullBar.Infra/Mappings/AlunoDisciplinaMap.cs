using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Infra.Mappings
{
    public class AlunoDisciplinaMap : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.ToTable("AlunoDisciplina", "dbo");

            builder.HasKey(c => new { c.AlunoId, c.DisciplinaId });

            builder.Property(x => x.Nota)
               .HasColumnType("decimal(2,2)")
               .IsRequired();
        }
    }
}
