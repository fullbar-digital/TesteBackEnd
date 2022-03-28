namespace Api.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int RA { get; set; }
        public string Periodo { get; set; }
        public int CursoID { get; set; }
        public Curso Curso { get; set; }
        public string Status { get; set; }
        public string Foto { get; set; }
        public List<AlunoDisciplina> Disciplinas { get; set; }
    }
}
