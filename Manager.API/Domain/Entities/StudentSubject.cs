using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Mappings.Data;

namespace Domain.Entities
{
   public class StudentSubject: Base
    {
        public virtual int StudentId { get; set; }
        public Student Student { get; set; }
        public virtual int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public decimal Note { get; set; }
        public string Status { get; set; }
        

        public StudentSubject() { }

        public StudentSubject(int studentid, Student student, int subjectid, Subject subject, decimal note, string status)
        {
            StudentId = studentid;
            Student = student;
            SubjectId = subjectid;
            Subject = subject;
            Note = note;
            Status = status;
        }

        public void UpdateNote(decimal note, string status, int code)
        {
            Code = code;
            Note = note;
            Status = status;
        }
        public override bool Validate()
        {
            var validador = new StudentSubjectMap();
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
