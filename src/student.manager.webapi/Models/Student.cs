using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using student.manager.webapi.Infraestructure;

namespace student.manager.webapi.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [JsonProperty("RA")]
        public string AcademicRecord { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Period { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        public string Status
        {
            get
            {
                string _status = "";

                if (Course.IsNull() || Course.Subjects.IsNull() || !Course.Subjects.Any())
                    return "";
                if(Course.Subjects.Count != (Grades?.Count ?? 0))
                    return "O aluno não possui nota em todas as matérias que está matriculado!";

                foreach (var grade in Grades)
                {
                    var subject = Course.Subjects.FirstOrDefault(s => s.SubjectId == grade.SubjectId);

                    if(grade.Value < subject.PassingScore)
                        _status += string.Format("Reprovado com nota {0} na matéria {1}!\n", grade.Value, subject.Name);
                    else
                        _status += string.Format("Aprovado com nota {0} na matéria {1}!\n", grade.Value, subject.Name);
                }

                return _status;
            }
        }

        [Required]
        public long CourseId { get; set; }
        public Course Course { get; set; }
        
        public List<Grade> Grades { get; set; }
    }
}
