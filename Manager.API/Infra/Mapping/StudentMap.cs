using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("TB_STUDENT");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("STU_CODE");

            builder.Property(x => x.Name)
                .HasColumnName("STU_NAME");

            builder.Property(x => x.RA)
                .HasColumnName("STU_RA");

            builder.Property(x => x.Turn)
                .HasColumnName("STU_TURN");

            builder.Property(x => x.Picture)
                .HasColumnName("STU_PICTURE");

            builder.Property(x => x.CodeCourse)
                .HasColumnName("STU_CODECOURSE");

            //builder.Property(x => x.)
            //  .HasColumnName("");

        }
    }
}
