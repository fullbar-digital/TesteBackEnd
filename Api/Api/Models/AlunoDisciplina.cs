namespace Api.Models
{
    public class AlunoDisciplina
    {
        public int Id { get; set; }
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }
        public int Nota { get; set; }
    }
}
