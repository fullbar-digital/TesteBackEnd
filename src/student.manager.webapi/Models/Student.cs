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

        public string Name { get; set; }

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
                
                return _status;
            }
        }

        [JsonIgnore]
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public static implicit operator Student(EntityEntry<Student> v)
        {
            throw new NotImplementedException();
        }
    }
}
