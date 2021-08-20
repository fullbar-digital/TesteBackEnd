using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fullbar.Entities.Models.Enrollments
{
	static class StudentStatus
	{
		public const string Approved = "Approved";
		public const string Reproved = "Reproved";
	}

	public class Enrollment
	{
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int DisciplineID { get; set; }

        public string Status
        {
            get
            {
                return StudentStatus.Approved;
            }
        }

        public Course Course { get; set; }
        public Student Student { get; set; }
        public Discipline Discipline { get; set; }
    }
}
