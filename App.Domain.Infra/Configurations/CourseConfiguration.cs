using System;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Domain.Infra.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("COURSES");


            builder.Property(p => p.Id)
                    .HasColumnName("ID");

            builder.Property(p => p.Name)
                    .HasColumnType("varchar(150)")
                    .IsRequired()
                    .HasColumnName("NAME");
        }
    }
}