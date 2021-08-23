using Fullbar.Entities.Models.Disciplines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fullbar.Entities.Models.Courses
{
	public class Course
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long CourseID { get; set; }

		public string Name { get; set; }

		public IList<Discipline> Disciplines { get; set; }
	}
}
