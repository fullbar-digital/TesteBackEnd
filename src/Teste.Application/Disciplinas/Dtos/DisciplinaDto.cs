namespace Teste.Application.Disciplinas.Dtos
{
    public class DisciplinaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public decimal NotaMinimaAprovacao { get; set; }
        public string Curso { get; set; } = default!;
    }
}
