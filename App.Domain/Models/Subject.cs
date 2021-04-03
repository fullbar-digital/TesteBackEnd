using System;
using System.Collections.Generic;

namespace App.Domain.Models
{
    public class Subject : Entity
    {
        public Subject()
        {

        }
        public Subject(string name, double MinAverageApproval)
        {
            this.Name = name;
            this.MinAverageApproval = MinAverageApproval;

        }
        public string Name { get; set; }
        public double MinAverageApproval { get; set; }

        #region Releationships
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string Status { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        #endregion
    }
}