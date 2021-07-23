using System;
using System.Collections.Generic;

namespace AppAlunos.Business.Models
{
    public class Aluno : Entity
    {
        public string RegistroAcademico { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }

        /* Relacionamento */
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }

    }
}