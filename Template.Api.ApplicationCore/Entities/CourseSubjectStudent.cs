using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Api.ApplicationCore.Entities
{
    [Table("course_subject_student", Schema = "dbo")]
    public class CourseSubjectStudent
    {
        [Key]
        [Column("course_subject_student_id")]
        public int CourseSubjectStudentId { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Grade { get; set; }

        public bool Status { get; set; }

        [Column("course_subject_id")]
        public int CourseSubjectId { get; set; }
        public virtual CourseSubject CourseSubject { get; set; }
    }
}