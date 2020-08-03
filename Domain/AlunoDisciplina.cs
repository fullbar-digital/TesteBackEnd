namespace Domain
{
    public class AlunoDisciplina
    {
        public double Nota { get; set; }
        public int AlunoDisciplinaId { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
