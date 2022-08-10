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

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }
    }
}
