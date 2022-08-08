namespace TesteBackEnd.Domain.Entities
{
    public class CourseEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<DisciplineEntity> Disciplines { get; set; }
        public CourseEntity()
        {
            Disciplines = new List<DisciplineEntity>();
        }
    }
}
