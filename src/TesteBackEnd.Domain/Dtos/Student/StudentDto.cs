using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AcademicRecord { get; set; }
        public string Period { get; set; }
        public Status Status { get; set; }
        public string StatusDetail { get; set; }
        public Guid CourseId { get; set; }
        public string Photo { get; set; }
        public ICollection<ScoreDto> Scores { get; set; }
    }
}
