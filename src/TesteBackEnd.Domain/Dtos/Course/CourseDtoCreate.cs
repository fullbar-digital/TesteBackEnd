using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Discipline;

namespace TesteBackEnd.Domain.Dtos.Course
{
    public class CourseDtoCreate : BaseDto
    {
        public string Name { get; set; }
    }
}
