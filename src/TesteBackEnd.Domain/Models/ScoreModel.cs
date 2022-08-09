using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Models
{
    public class ScoreModel
    {
        public Guid Id { get; set; }
        public decimal Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid DisciplineId { get; set; }
        public DisciplineModel Discipline { get; set; }
        private string _disciplineName;
        public string DisciplineName
        {
            get { return _disciplineName; }
            set { _disciplineName = Discipline.Name; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
    }
}
