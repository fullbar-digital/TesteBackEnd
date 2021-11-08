using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TesteBackend.Domain.Models
{
    /// <summary>
    /// Entidade para cadastro do aluno
    /// </summary>
    public class Aluno
    {
        /// <summary>
        /// Registro Acadêmico (RA) do aluno
        /// </summary>
        [Key]
        public int Ra { get; set; }

        /// <summary>
        /// Nome do aluno
        /// </summary>
        [Required(ErrorMessage = "O campo nome do aluno é obrigatório")]
        [MinLength(1, ErrorMessage = "O campo nome não pode ser vazio")]
        [MaxLength(100, ErrorMessage = "O campo nome tem tamanho máximo de 100 caracteres")]
        public string Nome { get; set; }
        
        /// <summary>
        /// Período do aluno no curso
        /// </summary>
        [Required(ErrorMessage = "O campo período é obrigatório")]
        public int Periodo { get; set; }

        /// <summary>
        /// Código do curso
        /// </summary>
        public int CursoId { get; set; }
        /// <summary>
        /// Curso do aluno
        /// </summary>
        public Curso Curso { get; set; }

        /// <summary>
        /// Lista de matrículas em disciplinas do aluno
        /// </summary>
        public virtual ICollection<Matricula> Matricula { get; private set; }

        /// <summary>
        /// Status do aluno no curso (Aprovado/Reprovado)
        /// </summary>
        public StatusResult Status { get; private set; }
        
        /// <summary>
        /// URL da foto do aluno
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Construtor da entidade aluno
        /// </summary>
        private Aluno() => this.Matricula = new List<Matricula>();

        /// <summary>
        /// Construtor da entidade aluno
        /// </summary>
        /// <param name="nome">Nome do aluno</param>
        /// <param name="periodo">Período do aluno no curso</param>
        /// <param name="curso">Curso do aluno</param>
        /// <param name="foto">URL da foto do aluno</param>
        /// <param name="matriculas">Lista de matrículas em disciplinas</param>
        public Aluno(string nome, int periodo, Curso curso, string foto, ICollection<Matricula> matriculas)
        {
            this.Nome = nome;
            this.Periodo = periodo;
            this.Curso = curso;
            this.CursoId = curso.Id;
            this.Foto = foto;
            this.Matricula = matriculas;

            this.Status = AtualizarStatusAluno(this.Matricula);
        }

        /// <summary>
        /// Altera o status do aluno
        /// </summary>
        /// <param name="statusResult">Novo status do aluno</param>
        public void AlterarStatus(StatusResult statusResult) => this.Status = statusResult;

        private StatusResult AtualizarStatusAluno(ICollection<Matricula> matricula)
            => matricula
                  .Where(m => m.Status == StatusResult.Reprovado)
                  .Select(m => m.Status)
                  .DefaultIfEmpty(StatusResult.Aprovado)
                  .FirstOrDefault();

        public override bool Equals(object obj)
        {
            Aluno aluno = (Aluno)obj;
            return this.Ra.Equals(aluno.Ra);
        }

    }
}
