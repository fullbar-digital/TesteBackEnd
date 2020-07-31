using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Infrastructure.Data.Mapping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CourseId)
                .HasColumnName("CursoId");

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Ra)
                .HasColumnName("Ra")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Grade)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Nota")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.OwnsOne(
                x => x.Period,
                period =>
                {
                    period.Property(x => x.Start).HasColumnName("PeriodoInicial").IsRequired();
                    period.Property(x => x.End).HasColumnName("PeriodoFinal").IsRequired();
                });

            builder
                .HasOne(u => u.Course)
                .WithMany(p => p.Students)
                .HasForeignKey(x => x.CourseId);

            builder.Property(x => x.Created).HasColumnName("DataCriacao").IsRequired();
            builder.Property(x => x.Updated).HasColumnName("DataAlteracao").IsRequired();

            builder.ToTable("Aluno", "dbo");
        }
    }
}