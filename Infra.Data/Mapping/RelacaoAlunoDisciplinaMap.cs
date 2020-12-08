using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class RelacaoAlunoDisciplinaMap : IEntityTypeConfiguration<RelacaoAlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<RelacaoAlunoDisciplina> builder)
        {
            builder.ToTable("AlunoDisciplina");

            builder.HasKey(o => o.Id);
        }
    }
}