using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Infrastructure.Data.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(u => u.Students)
                .WithOne(p => p.Course);

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Active)
                .HasColumnName("Ativo")
                .IsRequired();

            builder.Property(x => x.Created).HasColumnName("DataCriacao").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("DataAlteracao").IsRequired();

            builder.ToTable("Curso", "dbo");
        }
    }
}