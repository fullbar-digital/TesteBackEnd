using System;

namespace ApplicationCore.Domain.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Ra { get; set; }

        public string Status { get; set; }

        public string Course { get; set; }
        public short CourseId { get; set; }

        public string InitialDate { get; set; }
        public string EndDate { get; set; }

        public decimal Grade { get; set; }
    }
}