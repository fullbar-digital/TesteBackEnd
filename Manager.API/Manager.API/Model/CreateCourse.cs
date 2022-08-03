using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Model
{
    public class CreateCourse
    {
        public string Name { get; set; }
        public List<int> CodeSubject { get; set; }

        public CreateCourse() { }

        public CreateCourse(string name, List<int> codesubject)
        {
            Name = name;
            CodeSubject = codesubject;
        }
    }
}
