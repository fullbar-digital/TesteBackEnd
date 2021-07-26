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
                if (Grades.IsNull() || !Grades.Any())
                    _status = "O aluno não possui nota em nenhuma das matérias que está matriculado!";
                else
                {
                    foreach (var grade in Grades)
                    {
                        var subject = Course.Subjects.FirstOrDefault(s => s.SubjectId == grade.SubjectId);

                        if (grade.Value < subject.PassingScore)
                            _status += string.Format("Reprovado em {0}!\n", subject.Name);
                        else
                            _status += string.Format("Aprovado em {0}!\n", subject.Name);
                    }

                    if(Grades.Count != Course.Subjects.Count)
                    _status += "O aluno não possui nota nas demais matérias que está matriculado!";
                }

                return _status;
            }
        }

        [Required]
        public long CourseId { get; set; }

        public Course Course { get; set; }

        internal List<Grade> Grades { get; set; }

        /// <summary>
        /// Cria uma cópia que evita que as alterações feitas no objeto sejam refletidas direto no banco de dados
        /// </summary>        
        public Student DeepCopy()
        {
            return (Student)MemberwiseClone();
        }
    }
}
