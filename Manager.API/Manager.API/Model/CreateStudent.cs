using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Model
{
    public class CreateStudent
    {
        public string Name { get; set; }
        public string RA { get; set; }
        public string Turn { get; set; }
        public string Picture { get; set; }
        public int CodeCourse { get; set; }
        public CreateStudent() { }
        public CreateStudent(string name, string rA, string turn, string picture, int codecurse)
        {
            Name = name;
            RA = rA;
            Turn = turn;
            CodeCourse = codecurse;
        }
    }
}
