namespace TesteBackEnd.Domain.Entities
{
    public class CourseEntity : BaseEntity, ICourseEntity
    {
        public string Name { get; set; }
        public ICollection<DisciplineEntity> Disciplines { get; set; }
        public CourseEntity()
        {
            Disciplines = new List<DisciplineEntity>();
        }
    }

    public interface ICourseEntity : IBaseEntity
    {
        public string Name { get; set; }
        public ICollection<DisciplineEntity> Disciplines { get; set; }
    }
}
