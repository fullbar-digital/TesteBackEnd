using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Disciplina : BaseEntity
    {
        public string Nome { get; set; }
        public double NotaMinima { get; set; }
        public DateTime DisciplinaInicio { get; set; }
        public DateTime DisciplinaFim { get; set; }

        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }

        public List<RelacaoAlunoDisciplina> RelacaoAlunoDisciplinas { get; set; }
    }
}