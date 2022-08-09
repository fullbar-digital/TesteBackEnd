using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Entities
{
    public class ScoreEntity : BaseEntity
    {
        public decimal Score { get; set; }
        public StudentEntity Student { get; set; }
        public Guid StudentId { get; set; }
        public DisciplineEntity Discipline { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
