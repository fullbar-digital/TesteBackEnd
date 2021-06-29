using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteFullBar.Domain.Models
{
    public class Disciplina
    {
        public Disciplina()
        {
            AlunoDisciplinas = new HashSet<AlunoDisciplina>();
        }
        public Disciplina(int id, int cursoId, string descricao, decimal notaMinima, Curso curso, ICollection<AlunoDisciplina> alunoDisciplinas)
        {
            Id = id;
            CursoId = cursoId;
            Descricao = descricao;
            NotaMinima = notaMinima;
            Curso = curso;
            AlunoDisciplinas = alunoDisciplinas;
        }

        public int Id { get; set; }

        public int CursoId { get; set; }

        public string Descricao { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal NotaMinima { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
