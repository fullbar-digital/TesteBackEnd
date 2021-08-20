using Fullbar.Entities.Models.Enrollments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fullbar.Entities.Models.Students
{
	public class Student
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string RA { get; set; }

		public string Period { get; set; }

		public string Status { get; set; }

		public string Picture { get; set; }

		public long CurrentCourseId { get; set; }

		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
