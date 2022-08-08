using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackEnd.Domain.Dtos.Discipline
{
    public class DisciplineDtoCreate
    {
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public decimal MinimalScore { get; set; }

    }
}
