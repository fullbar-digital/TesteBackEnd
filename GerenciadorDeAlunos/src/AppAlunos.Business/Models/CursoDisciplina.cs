using System;

namespace AppAlunos.Business.Models
{
    public class CursoDisciplina : Entity
    {
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
        public Guid DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}