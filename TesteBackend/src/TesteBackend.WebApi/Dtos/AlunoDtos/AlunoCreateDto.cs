using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBackend.Domain.Models;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Dtos.AlunoDtos
{
    /// <summary>
    /// Entidade modelo para cadastrar novo aluno
    /// </summary>
    public class AlunoCreateDto
    {
        /// <summary>
        /// Nome do aluno
        /// </summary>
        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome do aluno não pode ser vazio")]
        public string Nome { get; set; }

        /// <summary>
        /// Período do aluno no curso
        /// </summary>
        [Required(ErrorMessage = "O período do aluno é obrigatório")]
        [Range(1, 9999, ErrorMessage = "O período precisa ser maior que Zero")]
        public int Periodo { get; set; }

        /// <summary>
        /// Código do curso
        /// </summary>
        [Required(ErrorMessage = "O código do curso é obrigatório")]
        public int CursoId { get; set; }
        
        /// <summary>
        /// Lista de matrículas em disciplinas
        /// </summary>
        [Required]
        public virtual ICollection<MatriculaCreateDto> Matricula { get; set; }

        public StatusResult Status { get; private set; } = StatusResult.Reprovado;

        public string Foto { get; set; }
    }
}
