using System.Collections.Generic;

namespace Domain
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; } = new List<Disciplina>();
        public List<Aluno> Alunos { get; } = new List<Aluno>();
    }
}
