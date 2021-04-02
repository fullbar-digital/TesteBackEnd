using System;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Domain.Infra.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("SUBJECTS");

            builder.Property(p => p.Id)
                    .HasColumnName("ID");

            builder.Property(p => p.Name)
                    .HasColumnType("varchar(150)")
                    .IsRequired()
                    .HasColumnName("NAME");

            builder.Property(p => p.MinAverageApproval)
                    .IsRequired()
                    .HasColumnName("MIN_AVERAGE_APPROVAL");

            builder.HasOne(p => p.Course)
                   .WithMany(u => u.Subjects)
                   .HasForeignKey(u => u.CourseId);
        }
    }
}