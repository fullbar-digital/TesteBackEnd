using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Domain.Dtos.Course
{
    public class CourseDtoUpdate : BaseDto
    {
        public string Name { get; set; }
    }
}
