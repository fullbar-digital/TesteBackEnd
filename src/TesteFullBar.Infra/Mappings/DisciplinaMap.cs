using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Infra.Mappings
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplina", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder.HasMany(x => x.AlunoDisciplinas)
                .WithOne(n => n.Disciplina)
                .HasForeignKey(n => n.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
