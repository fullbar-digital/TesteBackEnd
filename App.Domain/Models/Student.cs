using System;
using System.Collections.Generic;

namespace App.Domain.Models
{

    public class Student : Entity
    {
        public Student()
        {

        }

        public Student(string Name, string Register, string Period, Course Course, string Status, string Photo)
        {
            this.Name = Name;
            this.Register = Register;
            this.Period = Period;
            this.Status = Status;
            this.Photo = Photo;
            this.Course = Course;
        }
        public string Name { get; set; }
        public string Register { get; set; }
        public string Period { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }


        #region Releationships
        public Guid CourseId{ get; set; }
        public Course Course { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        #endregion


    }
}