namespace TesteBackEnd.Domain.Dtos.Discipline
{
    public class DisciplineDtoCreateResult
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public decimal MinimalScore { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
