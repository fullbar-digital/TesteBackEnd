using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace Infra.EntityConfigs
{
    public class DisciplinaConfig : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {

            builder.Property(a => a.NotaMinimaAprovacao)
                .IsRequired();


            builder.ToTable("Disciplinas");
        }
    }
}
