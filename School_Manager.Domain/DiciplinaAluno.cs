namespace School_Manager.Domain
{
    public class DiciplinaAluno
    {
        public int AlunoId {get; set;}
        public Aluno Aluno{get; set;}
        public int DiciplinaId {get; set;}
        public Diciplina Diciplina{get; set;}
        public float Nota{get; set;}
    }
}