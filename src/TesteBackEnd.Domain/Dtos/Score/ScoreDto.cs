using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Dtos.Score
{
    public class ScoreDto
    {
        public Guid Id { get; set; }
        public decimal Score { get; set; }
        public Status Status { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }

    }
}
