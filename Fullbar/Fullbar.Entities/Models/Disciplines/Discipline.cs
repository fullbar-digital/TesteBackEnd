using Fullbar.Entities.Models.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fullbar.Entities.Models.Disciplines
{
	public class Discipline
	{
		public long DisciplineID { get; set; }

		public string Name { get; set; }

		public double MinimumGrade { get; set; }

		[NotMapped]
		public string Status 
		{
			get
			{
				var status = String.Empty;
				foreach (var d in Grades)
				{
					status = (d.StudantGrade >= 7.0) ? "Aprovado" : "Reprovado";
				}

				return status;
			}
		}


		public long? CourseId{ get; set; }

		public Course Course { get; set; }

		public IList<Grade> Grades { get; set; }
	}
}
