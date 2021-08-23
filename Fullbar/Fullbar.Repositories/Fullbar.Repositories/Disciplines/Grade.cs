using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fullbar.Repositories.Disciplines
{
	public class Grade
	{
		public long GradeID { get; set; }
		public double StudantGrade { get; set; }

		public long DisciplineID { get; set; }
		public long StudentID { get; set; }
		
		public Student Student { get; set; }
		public Discipline Discipline { get; set; }
	}
}
