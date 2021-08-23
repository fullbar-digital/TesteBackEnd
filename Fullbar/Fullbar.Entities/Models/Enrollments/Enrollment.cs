using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fullbar.Entities.Models.Enrollments
{
	public class Enrollment
	{
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int DisciplineID { get; set; }

        [NotMapped]
        public Course Course { get; set; }

        [NotMapped]
        public Discipline Discipline { get; set; }
    }
}
