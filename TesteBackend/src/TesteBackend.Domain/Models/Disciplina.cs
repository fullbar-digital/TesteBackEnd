using System;
using System.Collections.Generic;

namespace TesteBackend.Domain.Models
{
    /// <summary>
    /// Entidade para cadastro da disciplina
    /// </summary>
    public class Disciplina
    {
        /// <summary>
        /// Identificação da disciplina
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da disciplina
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nota mínima para aprovação do aluno na disciplina
        /// </summary>
        public decimal NotaMinimaAprovacao { get; private set; }

        /// <summary>
        /// Identificador do curso
        /// </summary>
        public int CursoId { get; set; }

        /// <summary>
        /// Curso da disciplina
        /// </summary>
        public virtual Curso Curso { get; set; }
        
        /// <summary>
        /// Lista de alunos matriculados na disciplina
        /// </summary>
        public virtual IList<Matricula> DisciplinasMatricula { get; set; }

        /// <summary>
        /// Construtor utilizado pelo Entity Framework Core Migration
        /// </summary>
        private Disciplina() => ConfigDefault();

        /// <summary>
        /// Construtor da entidade disciplina
        /// </summary>
        /// <param name="nome">Nome da disciplina</param>
        /// <param name="curso">Curso que a disciplina será vinculada</param>
        public Disciplina(string nome, Curso curso)
        {
            this.Nome = nome;
            this.Curso = curso;
            this.CursoId = curso.Id;
            ConfigDefault();
        }

        public override bool Equals(object obj)
        {
            Disciplina disciplina = (Disciplina)obj;
            return this.Id.Equals(disciplina.Id);
        }

        /// <summary>
        /// Configura a nota mínima para aprovação nas disciplinas
        /// </summary>
        private void ConfigDefault()
        {
            Decimal notaMinimaAprovacao = 7;
            this.NotaMinimaAprovacao = notaMinimaAprovacao;
            this.DisciplinasMatricula = new List<Matricula>();
        }
    }
}
