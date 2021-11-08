using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackend.WebApi.Dtos.DisciplinaDtos
{
    /// <summary>
    /// Modelo para alteração dos dados de matrícula
    /// </summary>
    public class MatriculaEditDto
    {   
        /// <summary>
        /// Identificador da disciplina
        /// </summary>
        [Required]
        public int DisciplinaId { get; set; }

        /// <summary>
        /// Nota do aluno
        /// </summary>
        [Required(ErrorMessage = "A nota é obrigatória")]
        [Range(0.0, 10.0, ErrorMessage = "A escala de nota vai de 0(zero) até 10(dez)")]
        public decimal Nota { get; set; }
    }
}
