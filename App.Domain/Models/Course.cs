using System.Collections.Generic;

namespace App.Domain.Models
{
    public class Course : Entity
    {
        public Course()
        {
            this.Subjects = new HashSet<Subject>();
            this.Students = new HashSet<Student>();

        }
        public Course(string name, ICollection<Subject> Subjects, ICollection<Student> Students)
        {
            this.Name = name;
            this.Subjects = Subjects;
            this.Students = Students;

        }
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}