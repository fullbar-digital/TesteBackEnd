using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Dtos.AlunoDtos
{
    /// <summary>
    /// Modelo para edição do cadastro do aluno
    /// </summary>
    public class AlunoEditDto
    {
        /// <summary>
        /// Registro Acadêmico (RA) do aluno
        /// </summary>
        [Key]
        public int Ra { get; set; }

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
        /// Lista de matriculas do aluno em disciplinas
        /// </summary>
        public virtual ICollection<MatriculaEditDto> Matricula { get; set; }
        
        /// <summary>
        /// URL da foto do aluno
        /// </summary>
        public string Foto { get; set; }
    }
}
