using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(p => p.CreatedAt)
               .HasDefaultValue(DateTime.Now)
               .IsRequired();
        }
    }
}
