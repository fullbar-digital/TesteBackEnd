using Domain.Mappings.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Entities
{
    public class Course : Base
    {
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual ICollection<CourseSubject> CourseSubject { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course() { }

        public Course(string name, DateTime createdate)
        {
            Name = name;
            CreateDate = createdate;
            _errors = new List<string>();

            Validate();
        }

        public void UpdateCourse(string name)
        {
            Name = name;
        }

        public override bool Validate()
        {
            var validator = new CourseMap();
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
