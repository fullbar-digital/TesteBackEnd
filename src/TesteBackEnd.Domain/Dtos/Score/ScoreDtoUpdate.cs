namespace TesteBackEnd.Domain.Dtos.Score
{
    public class ScoreDtoUpdate
    {
        public Guid Id { get; set; }
        public decimal Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
