using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Models
{
    public class StudentModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _academicRecord;
        public string AcademicRecord
        {
            get { return _academicRecord; }
            set { _academicRecord = value; }
        }

        private string _period;
        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        private string _courseId;
        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }


        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private string _statusDetail;
        public string StatusDetail
        {
            get { return _statusDetail; }
            set { _statusDetail = value; }
        }
        public ICollection<ScoreModel> Scores { get; set; }
        private Status _status;
        public Status Status
        {
            get { return _status; }
            set
            {
                if (Scores.Any())
                {
                    var score = Scores.Where(s => s.Score < 7).FirstOrDefault();
                    StatusDetail = (score != null) ? $"Reprovado na disciplina {score.Discipline.Name}" : "Aprovado";
                    _status = (score != null) ? Status.DISAPPROVED : value;
                }
                else
                {
                    StatusDetail = "Aluno sem nota nas disciplinas";
                    _status = Status.SCORELESS;
                }

            }
        }
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

    }
}
