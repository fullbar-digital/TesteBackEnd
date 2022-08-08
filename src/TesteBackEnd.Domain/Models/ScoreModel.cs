using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Models
{
    public class ScoreModel
    {
        public Guid Id { get; set; }
        public decimal Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
        private Status _status;
        public Status Status
        {
            get { return Score >= 7 ? Status.APPROVED : Status.DISAPPROVED; }
        }

    }
}
