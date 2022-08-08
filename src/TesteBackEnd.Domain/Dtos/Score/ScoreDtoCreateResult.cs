namespace TesteBackEnd.Domain.Dtos.Score
{
    public class ScoreDtoCreateResult
    {
        public Guid Id { get; set; }
        public decimal Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
