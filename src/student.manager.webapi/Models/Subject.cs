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
        internal List<Course> Courses { get; set; }

        [JsonIgnore]
        internal List<CourseSubject> CourseSubjects { get; set; }

        /// <summary>
        /// Cria uma cópia que evita que as alterações feitas no objeto sejam refletidas direto no banco de dados
        /// </summary>        
        public Subject DeepCopy()
        {
            return (Subject)MemberwiseClone();
        }
    }
}
