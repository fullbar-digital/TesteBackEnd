using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityTypeConfiguration
{
    public class CourseConfiguration : BaseEntityTypeConfiguration<Course> {}
    public class StudentConfiguration : BaseEntityTypeConfiguration<Student> {}
    public class SubjectConfiguration : BaseEntityTypeConfiguration<Subject> {}

    public class SchoolReportConfiguration : BaseEntityTypeConfiguration<SchoolReport>
    {
        public override void Configure(EntityTypeBuilder<SchoolReport> builder)
        {
            base.Configure(builder);

            builder.HasOne(one => one.Student).WithMany(wm => wm.SchoolReports).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(one => one.Subject).WithMany(wm => wm.SchoolReports).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
