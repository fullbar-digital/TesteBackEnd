using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(s => s.AcademicRecord)
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15)
                    .IsRequired();
            builder.Property(s => s.Period)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(p => p.Status)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(s => s.Photo)
               .HasColumnType("varchar(500)")
               .HasMaxLength(500);
            builder.Property(p => p.CreatedAt)
               .HasDefaultValue(DateTime.Now)
               .IsRequired();
        }
    }
}
