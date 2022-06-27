using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Api.ApplicationCore.Entities
{
    [Table("course", Schema = "dbo")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public int CourseId { get; set; }
        public string Name { get; set; }
    }
}