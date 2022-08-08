using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Student
{
    public class StudentDtoUpdateResult
    {
        public string Name { get; set; }
        public string AcademicRecord { get; set; }
        public string Period { get; set; }
        public Guid CourseId { get; set; }
        public string Photo { get; set; }
    }
}
