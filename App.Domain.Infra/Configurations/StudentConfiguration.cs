using System;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Domain.Infra.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("STUDENTS");

            builder.Property(p => p.Id)
                    .HasColumnName("ID");

            builder.Property(p => p.Name)
                    .HasColumnType("varchar(150)")
                    .IsRequired()
                    .HasColumnName("NAME");

            builder.Property(p => p.Register)
                    .IsRequired()
                    .HasColumnName("REGISTER");

            builder.Property(p => p.Period)
                    .IsRequired()
                    .HasColumnName("PERIOD");

            builder.Property(p => p.Status)
                    .IsRequired()
                    .HasColumnName("STATUS");

            builder.Property(p => p.Photo)
                    .IsRequired()
                    .HasColumnName("PHOTO");

            builder.HasOne(p => p.Course)
                   .WithMany(u => u.Students)
                   .HasForeignKey(u => u.CourseId);

        }
    }
}