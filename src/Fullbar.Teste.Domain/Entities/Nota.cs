using System;

namespace Fullbar.Teste.Domain.Entities
{
    public class Nota : Entity
    {
        public Guid DisciplinaId { get; set; }
        public Guid AlunoId { get; set; }
        public decimal Valor { get; set; }
        public Disciplina Disciplina { get; set; }
        public Aluno Aluno { get; set; }
    }
}