using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Mappings
{
    public class ScoreMapping : IEntityTypeConfiguration<ScoreEntity>
    {
        public void Configure(EntityTypeBuilder<ScoreEntity> builder)
        {
            builder.ToTable("Scores");

            builder.HasKey(s => s.Id);
            builder.Property(p => p.StudentId)
              .IsRequired();
            builder.Property(p => p.DisciplineId)
             .IsRequired();

            builder.Property(s => s.Score)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.CreatedAt)
               .HasDefaultValue(DateTime.Now)
               .IsRequired();

            builder.HasOne("TesteBackEnd.Domain.Entities.DisciplineEntity", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

            builder.HasOne("TesteBackEnd.Domain.Entities.StudentEntity", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
        }
    }
}
