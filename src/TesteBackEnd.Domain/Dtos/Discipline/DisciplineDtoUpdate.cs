namespace TesteBackEnd.Domain.Dtos.Discipline
{
    public class DisciplineDtoUpdate : BaseDto
    {
        public string Name { get; set; }
        public decimal MinimalScore { get; set; }
        public Guid CourseId { get; set; }
    }
}
