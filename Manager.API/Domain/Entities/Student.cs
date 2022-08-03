using System;
using System.Collections.Generic;
using System.Text;
using Domain.Mappings.Data;


namespace Domain.Entities
{
    public class Student : Base
    {
        public string Name { get; set; }
        public string RA { get; set; }
        public string Turn { get; set; }
        public string Picture { get; set; }
        public virtual int CodeCourse { get; set; }
        public Course Course { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public Student() { }
        public Student(string name, string rA, string turn, string picture, int codecourse, Course course)
        {
            Name = name;
            RA = rA;
            Turn = turn;
            Picture = picture;
            CodeCourse = codecourse;
            Course = course;
            _errors = new List<string>();

            Validate();
        }

        public void StudentUpdate(string name, string rA, string turn, string picture, int codecourse)
        {
            Name = name;
            RA = rA;
            Turn = turn;
            Picture = picture;
            CodeCourse = codecourse;
        }

        public override bool Validate()
        {
            var validator = new StudentMap();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors = new List<string>();
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    
    }
}
