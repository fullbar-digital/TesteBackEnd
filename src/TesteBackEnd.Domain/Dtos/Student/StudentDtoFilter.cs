using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Student
{
    public class StudentDtoFilter
    {

        public string Name { get; set; }
        public string AcademicRecord { get; set; }
        public string CourseName { get; set; }
        public Status Status { get; set; }
    }
}
