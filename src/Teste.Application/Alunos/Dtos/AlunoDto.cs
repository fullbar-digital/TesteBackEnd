namespace Teste.Application.Alunos.Dtos
{
    public class AlunoDto
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string RegistroAcademico { get; set; } = default!;
        public int Periodo { get; set; } = default!;
        public string Curso { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Foto { get; set; } = default!;
    }
}
