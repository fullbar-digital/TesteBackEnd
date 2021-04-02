using System;

namespace App.Domain.Models
{
    public class StudentSubject : Entity
    {
        public StudentSubject()
        {

        }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid SubjectId  { get; set; }
        public Subject Subject { get; set; }
        public double  Average { get; set; }
        public string  Status { get; set; }

    }
}