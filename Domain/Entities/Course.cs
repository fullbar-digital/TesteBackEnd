using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course : EntityBase
    {
        public Course()
        {
            Subjects = new List<Subject>();
        }
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
