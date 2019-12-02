using System.ComponentModel.DataAnnotations;

namespace BancoAlunos.Models
{
    public class Alunos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int RA { get; set; }
        public string Periodo { get; set; }
        public string Curso { get; set; }
        public decimal Nota { get; set; }
    }
}
