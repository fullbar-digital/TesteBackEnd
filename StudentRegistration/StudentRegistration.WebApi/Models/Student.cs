using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistration.WebApi.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int AR { get; set; }

        public string Name { get; set; }

        public int Period { get; set; }

        public int Course { get; set; }

        public double Grade { get; set; }

        public int Status { get; set; }
    }
}
