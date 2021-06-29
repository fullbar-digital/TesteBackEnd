using System.Collections.Generic;

namespace TesteFullBar.API.ViewModels.Aluno
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public string RA { get; set; }

        public string Periodo { get; set; }

        public string Status { get; set; }

        public int CursoId { get; set; }

        public List<AlunoDisciplinaViewModel> Disciplinas { get; set; }         

        public void SetStatus(string status)
        {
            Status = status;
        }
    }
}
