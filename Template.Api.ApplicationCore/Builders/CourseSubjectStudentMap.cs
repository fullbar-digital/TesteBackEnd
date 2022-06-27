using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Builders
{
    public class CourseSubjectStudentMap
    {
        public CourseSubjectStudentMap(EntityTypeBuilder<CourseSubjectStudent> entityBuilder)
        {
            entityBuilder.HasKey(sc => new { sc.CourseSubjectId, sc.CourseSubjectStudentId, sc.StudentId });
        }
    }
}