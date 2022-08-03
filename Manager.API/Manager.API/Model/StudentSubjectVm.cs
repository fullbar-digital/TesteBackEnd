using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Model
{
    public class StudentSubjectVm
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public float Note { get; set; }

        public StudentSubjectVm() { }

        public StudentSubjectVm(int studentid, int subjectid, float note)
        {
            StudentId = studentid;
            SubjectId = subjectid;
            Note = note;
        }
    }
}
