using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Builders
{
    public class StudentMap
    {
        public StudentMap(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.HasKey(t => t.StudentId);
            entityBuilder.Property(e => e.Status).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}