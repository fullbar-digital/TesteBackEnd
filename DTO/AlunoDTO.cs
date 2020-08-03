using System.Collections.Generic;

namespace DTO
{
    public class AlunoDTO
    {
        public AlunoDTO()
        {
            Disciplinas = new List<DisciplinaDTO>();
        }
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public int Periodo { get; set; }
        public string Foto { get; set; }

        public string Curso { get; set; }
        public List<DisciplinaDTO> Disciplinas { get; set; }
    }
}
