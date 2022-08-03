using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class SubjectMaps : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("TB_SUBJECT");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("SUB_CODE");

            builder.Property(x => x.Name)
                .HasColumnName("SUB_NAME");

            builder.Property(x => x.ApproveMin)
                .HasColumnName("SUB_APPROVE_MIN");

            builder.Property(x => x.CreateData)
                .HasColumnName("SUB_CREATE_DATA");

        }
    } 
}
