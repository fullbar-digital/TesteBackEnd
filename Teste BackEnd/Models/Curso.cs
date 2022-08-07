using System.Collections.Generic;

namespace Teste_BackEnd.Models
{
    public class Curso : BaseModel
    {
        public IList<Disciplina> Disciplinas { get; set; }
    }
}
