using System.Collections.Generic;

namespace TesteBackend.Domain.Models
{
    /// <summary>
    /// Entidade para cadastro do curso
    /// </summary>
    public class Curso
    {
        /// <summary>
        /// Identificador do curso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do curso
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Lista de disciplinas do curso
        /// </summary>
        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        /// <summary>
        /// Lista de alunos matriculados no curso
        /// </summary>
        public virtual ICollection<Aluno> Alunos { get; set; }

        private Curso() => InicializeLists();

        public Curso(string nome)
        {
            this.Nome = nome;
            InicializeLists();
        }

        private void InicializeLists()
        {
            this.Disciplinas = new List<Disciplina>();
            this.Alunos = new List<Aluno>();
        }

        public override bool Equals(object obj)
        {
            Curso cursoComp = (Curso)obj;
            return this.Id.Equals(cursoComp.Id);
        }
    }
}
