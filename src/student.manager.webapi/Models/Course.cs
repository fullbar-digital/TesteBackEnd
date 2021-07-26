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
        internal List<CourseSubject> CourseSubjects { get; set; }

        [JsonIgnore]
        internal List<Student> Students { get; set; }

        /// <summary>
        /// Cria uma cópia que evita que as alterações feitas no objeto sejam refletidas direto no banco de dados
        /// </summary>        
        public Course DeepCopy()
        {
            return (Course)MemberwiseClone();
        }
    }
}
