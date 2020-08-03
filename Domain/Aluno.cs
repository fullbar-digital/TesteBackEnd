using System.Collections.Generic;

namespace Domain
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public int Periodo { get; set; }
        public byte Status { get; set; }
        public string Foto { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public List<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
