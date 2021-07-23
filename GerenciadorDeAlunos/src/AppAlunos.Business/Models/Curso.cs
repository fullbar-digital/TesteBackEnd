using System.Collections.Generic;

namespace AppAlunos.Business.Models
{
    public class Curso : Entity
    {
        public string Nome { get; set; }

        /* Relacionamento */
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; set; }
#nullable enable
        public IEnumerable<Aluno>? Alunos { get; set; }
    }
}