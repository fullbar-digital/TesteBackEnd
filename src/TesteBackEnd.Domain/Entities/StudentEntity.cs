using TesteBackEnd.Domain.Enums;
namespace TesteBackEnd.Domain.Entities
{
    public class StudentEntity : BaseEntity
    {
        public StudentEntity()
        {
            Scores = new List<ScoreEntity>();
        }
        public string Name { get; set; }
        public string AcademicRecord { get; set; }
        public string Period { get; set; }
        public CourseEntity Course { get; set; }
        public Guid CourseId { get; set; }
        public string Photo { get; set; }
        public ICollection<ScoreEntity> Scores { get; set; }
    }
}
