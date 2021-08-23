using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Models.Disciplines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fullbar.Entities.Models.Students
{
	public class Student
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string RA { get; set; }

		public string Period { get; set; }

		public string Picture { get; set; }

		public long CourseId { get; set; }
		public Course Course { get; set; }
	}
}
