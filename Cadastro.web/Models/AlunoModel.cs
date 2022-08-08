namespace Cadastro.web.Models
{
    public class AlunoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public decimal Ra { get; set; }

        public string Periodo { get; set; }

        public string Curso { get; set; }

        public string Status { get; set; }

        public string Foto { get; set; }
    }
}
