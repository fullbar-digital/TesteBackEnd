using System;

namespace AppAlunos.Business.Models
{
    public class AlunoDisciplina : Entity
    {
        public Guid AlunoId { get; set; } = Guid.NewGuid();
        public Aluno Aluno { get; set; }
        public Guid DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public double Nota { get; set; }
        public string Status { get; set; }

    }
}