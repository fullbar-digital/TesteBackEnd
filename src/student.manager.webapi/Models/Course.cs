using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace student.manager.webapi.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public List<Subject> Subjects { get; set; }
                
        [JsonIgnore]
        public List<CourseSubject> CourseSubjects { get; set; }
    }
}
