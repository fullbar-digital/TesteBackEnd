using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Api.ApplicationCore.Entities
{
    [Table("course_subject", Schema = "dbo")]
    public class CourseSubject
    {
        [Key]
        [Column("course_subject_id")]
        public int CourseSubjectId { get; set; }
        public string Name { get; set; }
        [Column("minimum_grade", TypeName = "decimal(10,2)")]
        public decimal MinimumGrade { get; set; }
        [Column("course_id")]
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }
    }
}
