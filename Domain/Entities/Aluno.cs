using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Ra { get; set; }
        public string Periodo { get; set; }
        public string Status { get; set; }
        public string Foto { get; set; }

        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }

        public List<RelacaoAlunoDisciplina> RelacaoAlunoDisciplinas { get; set; }
    }
}