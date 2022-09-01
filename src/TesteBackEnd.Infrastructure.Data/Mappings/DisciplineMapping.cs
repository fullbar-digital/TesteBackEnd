using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Mappings
{
    public class DisciplineMapping : IEntityTypeConfiguration<DisciplineEntity>
    {
        public void Configure(EntityTypeBuilder<DisciplineEntity> builder)
        {
            builder.ToTable("Disciplines");

            builder.HasKey(s => s.Id);
            builder.Property(p => p.CourseId)
              .IsRequired();
            builder.Property(s => s.Name)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(s => s.MinimalScore)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            builder.Property(p => p.CreatedAt)
               .HasDefaultValue(DateTime.Now)
               .IsRequired();
        }
    }
}
