namespace Api.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string Nome { get; set; }
        public List<CursoDisciplina> Disciplinas { get; set; }

    }
}
