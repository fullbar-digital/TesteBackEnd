using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Common.Entities;

namespace Teste.Infra.Data.Mappings
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Id).HasColumnName("ID");
        }

        public abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
    }
}
