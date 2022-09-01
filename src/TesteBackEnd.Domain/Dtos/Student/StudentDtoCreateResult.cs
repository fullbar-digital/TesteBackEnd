using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Student
{
    public class StudentDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AcademicRecord { get; set; }
        public string Period { get; set; }
        public Guid CourseId { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
