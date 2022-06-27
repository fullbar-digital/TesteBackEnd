namespace Teste.Domain.Alunos.Dto
{
    public class FilterAlunoDto
    {
        public string Nome { get; set; } = default!;
        public string RegistroAcademico { get; set; } = default!;
        public string Curso { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
