namespace TesteFullBar.API.ViewModels.Disciplina
{
    public class DisciplinaViewModel
    {
        public DisciplinaViewModel()
        {
            
        }

        public int Id { get; set; }

        public int CursoId { get; set; }

        public string Descricao { get; set; }

        public decimal NotaMinima { get; set; }
    }
}
