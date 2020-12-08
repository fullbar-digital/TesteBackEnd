using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class AlunoDtoCreate
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "RA é obrigatório")]
        public string Ra { get; set; }

        public string Periodo { get; set; }

        public string Foto { get; set; }

        [Required(ErrorMessage = "Curso é obrigatório")]
        public Guid CursoId { get; set; }
    }
}