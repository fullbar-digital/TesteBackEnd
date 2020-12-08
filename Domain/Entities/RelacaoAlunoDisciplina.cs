using System;

namespace Domain.Entities
{
    public class RelacaoAlunoDisciplina : BaseEntity
    {
        public double Nota { get; set; }

        public Guid RelacaoAlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public Guid RelacaoDisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}