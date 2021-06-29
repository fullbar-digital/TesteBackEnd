using System.Collections.Generic;

namespace TesteFullBar.Domain.Models
{
    public class Curso
    {
        public Curso()
        {
            Disciplinas = new HashSet<Disciplina>();
            Alunos = new HashSet<Aluno>();
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
