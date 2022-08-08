namespace TesteBackEnd.Domain.Entities
{
    public class DisciplineEntity : BaseEntity
    {
        public string? Name { get; set; }
        public decimal MinimalScore { get; set; }
    }
}