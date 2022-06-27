using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Builders
{
    public class CourseSubjectMap
    {
        public CourseSubjectMap(EntityTypeBuilder<CourseSubject> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CourseSubjectId);
        }
    }
}