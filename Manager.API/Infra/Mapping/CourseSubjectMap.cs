using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class CourseSubjectMap : IEntityTypeConfiguration<CourseSubject>
    {
        public void Configure(EntityTypeBuilder<CourseSubject> builder)
        {
            builder.ToTable("TB_COURSE_SUBJECT");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("CSU_CODE");

            builder.Property(x => x.CourseId)
                .HasColumnName("CSU_COURSEID");

            builder.Property(x => x.SubjectId)
                .HasColumnName("CSU_SUBJECTID");

            //builder.Property(x => x.)
            //    .HasColumnName("");
        }
    }
}
