using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Student : EntityBase
    {
        public Student()
        {
            SchoolReports = new List<SchoolReport>();
        }

        public string Name { get; set; }
        public string Ra { get; set; }
        public int Period { get; set; }
        public Guid CourseId { get; set; }
        public string ProfilePicture { get; set; }

        public string Status { get; set; }

        public Course Course { get; set; }

        public List<SchoolReport> SchoolReports { get; set; }
    }
}
