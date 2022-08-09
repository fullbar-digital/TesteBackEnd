using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Score
{
    public class ScoreDto
    {
        public string DisciplineName { get; set; }
        public decimal Score { get; set; }
    }
}
