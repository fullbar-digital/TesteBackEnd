using Domain.Mappings.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Subject : Base
    {
        public string Name { get; set; }
        public int ApproveMin { get; set; }
        public DateTime? CreateData { get; set; }
        public ICollection<CourseSubject> CourseSubject { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }

        public Subject() { }

        public Subject(string name, int approvemin, DateTime createdata)
        {
            Name = name;
            ApproveMin = approvemin;
            CreateData = createdata;
            _errors = new List<string>();

            Validate();
        }

        public override bool Validate()
        {
            var validator = new SubjectMap();
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

        public void UpdateSub(string name, int approvemin)
        {
            Name = name;
            ApproveMin = approvemin;
            Validate();
        }
    }
}
