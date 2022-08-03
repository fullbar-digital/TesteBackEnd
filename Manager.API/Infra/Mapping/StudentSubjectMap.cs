using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    public class StudentSubjectMap : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("TB_STUDENT_SUBJET");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("SSU_CODE");

            builder.Property(x => x.StudentId)
                .HasColumnName("SSU_STUCODE");

            builder.Property(x => x.SubjectId)
                .HasColumnName("SSU_SUBCODE");

            builder.Property(x => x.Note)
                .HasColumnName("SSU_NOTE");

            builder.Property(x => x.Status)
                .HasColumnName("SSU_STATUS");


            //builder.Property(x => x.)
            //    .HasColumnName("");
        }
    }
}
