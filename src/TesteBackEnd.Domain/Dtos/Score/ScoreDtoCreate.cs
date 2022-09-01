namespace TesteBackEnd.Domain.Dtos.Score
{
    public class ScoreDtoCreate
    {
        public decimal Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
