using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Builders
{
    public class CourseMap
    {
        public CourseMap(EntityTypeBuilder<Course> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CourseId);
        }
    }
}