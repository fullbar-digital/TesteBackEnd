using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(s => s.Id);
        }
    }
}
