using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Api.ApplicationCore.Entities
{
    public class Student : StudentBase
    {
        [Key]
        [Column(name: "student_id")]
        public int StudentId { get; set; }

        public virtual IEnumerable<CourseSubjectStudent> CourseSubjectStudent { get; set; }
    }
}