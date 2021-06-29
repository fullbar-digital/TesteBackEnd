namespace TesteFullBar.API.ViewModels.Aluno.Query
{
    public class AlunoQueryViewModel
    {
        public AlunoQueryViewModel()
        {
           
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public string RA { get; set; }

        public string Periodo { get; set; }

        public string Status { get; set; }

        public int CursoId { get; set; }

        public string CursoDescricao { get; set; }
    }
}
