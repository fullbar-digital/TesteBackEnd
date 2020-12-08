using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime CursoInicio { get; set; }
        public DateTime CursoFim { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}