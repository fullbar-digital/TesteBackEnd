namespace TesteBackEnd.Domain.Dtos.Discipline
{
    public class DisciplineDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal MinimalScore { get; set; }
        public Guid CourseId { get; set; }
    }
}
