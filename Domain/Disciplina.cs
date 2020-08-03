using System.Collections.Generic;

namespace Domain
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public double NotaMinimaAprovacao { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public List<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
