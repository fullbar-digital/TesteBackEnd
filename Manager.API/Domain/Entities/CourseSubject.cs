using Domain.Mappings.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CourseSubject : Base
    {
        public virtual int CourseId { get; set; }
        public Course Course { get; set; }
        public virtual int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public CourseSubject() { }

        public CourseSubject(int courseid, Course course, int subjectid, Subject subject)
        {
            CourseId = courseid;
            Course = course;
            SubjectId = subjectid;
            Subject = subject;
        }
        public override bool Validate()
        {
            var validador = new CourseSubjectMap();
            var validation = validador.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
