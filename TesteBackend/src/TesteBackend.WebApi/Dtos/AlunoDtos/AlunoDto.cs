using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBackend.Domain.Models;
using TesteBackend.WebApi.Dtos.CursoDtos;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Dtos.AlunoDtos
{
    /// <summary>
    /// Modelo do cadastro do aluno
    /// </summary>
    public class AlunoDto
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
        [MinLength(1, ErrorMessage = "O campo período não pode ser menor que Zero")]
        public int Periodo { get; set; }

        /// <summary>
        /// Status do aluno no curso
        /// </summary>
        public StatusResult Status { get; private set; }

        /// <summary>
        /// Curso do aluno
        /// </summary>
        public virtual CursoDto Curso { get; set; }

        /// <summary>
        /// Lista de matrículas do aluno em disciplinas
        /// </summary>
        public virtual ICollection<MatriculaDto> Matricula { get; set; }

        /// <summary>
        /// URL da foto do aluno
        /// </summary>
        public string Foto { get; set; }
    }
}
