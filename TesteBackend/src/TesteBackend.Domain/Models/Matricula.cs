using TesteBackend.Domain.Validation;

namespace TesteBackend.Domain.Models
{
    /// <summary>
    /// Entidade para cadastrar a matrícula do aluno na disciplina
    /// </summary>
    public class Matricula
    {
        /// <summary>
        /// RA (Registro Acadêmico) do aluno
        /// </summary>
        public int AlunoRa { get; private set; }

        /// <summary>
        /// Entidade aluno para cadastro
        /// </summary>
        public virtual Aluno Aluno { get; private set; }

        /// <summary>
        /// Código da disciplina
        /// </summary>
        public int DisciplinaId { get; private set; }

        /// <summary>
        /// Entidade disciplina para cadastro
        /// </summary>
        public virtual Disciplina Disciplina { get; private set; }

        /// <summary>
        /// Nota do aluno na disciplina
        /// </summary>
        public decimal Nota { get; private set; }

        /// <summary>
        /// Status do aluno na disciplina
        /// </summary>
        public StatusResult Status { get; private set; }

        /// <summary>
        /// Construtor padrão da matrícula
        /// </summary>
        private Matricula()
        {
        }

        /// <summary>
        /// Construtor padrão da matrícula
        /// </summary>
        /// <param name="aluno">Aluno para matricular</param>
        /// <param name="disciplina">Disciplina para matricular</param>
        /// <param name="nota">Nota do aluno</param>
        public Matricula(Aluno aluno, Disciplina disciplina, decimal nota)
        {
            this.Aluno = aluno;
            this.AlunoRa = aluno.Ra;
            this.Disciplina = disciplina;
            this.DisciplinaId = disciplina.Id;
            this.Nota = nota;

            if (this.Disciplina is not null)
                AtualizaStatus();
        }

        /// <summary>
        /// Atualizar a nota do aluno e status
        /// </summary>
        /// <param name="notaNova"></param>
        public void AtualizaNota(decimal notaNova)
        {
            this.Nota = notaNova;
            AtualizaStatus();
        }

        /// <summary>
        /// Alterar status na disciplina
        /// </summary>
        private void AtualizaStatus()
            => this.Status = NotaValidation.Validate(this.Nota, this.Disciplina.NotaMinimaAprovacao);
    }
}
