using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("CRS_CODE");

            builder.Property(x => x.Name)
                .HasColumnName("CRS_NAME");

            builder.Property(x => x.CreateDate)
                .HasColumnName("CRS_CREATE_DATE");

        }
    }
}
