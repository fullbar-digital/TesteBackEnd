using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace student.manager.webapi.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubjectId { get; set; }

        public string Name { get; set; }
        
        [Required]
        public double PassingScore { get; set; }

        [JsonIgnore]
        public List<Course> Courses { get; set; }

        [JsonIgnore]
        public List<CourseSubject> CourseSubjects { get; set; }
    }
}
