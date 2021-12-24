
using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace Repositories.EntityTypeConfiguration
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");

            builder.Property<Guid>("Id")
                .HasDefaultValueSql("newid()")
                .ValueGeneratedOnAdd();

            builder.Property<DateTime>("CreateDate")
                .IsRequired()
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();

            builder.Property<DateTime>("UpdateDate")
                .IsRequired()
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}

