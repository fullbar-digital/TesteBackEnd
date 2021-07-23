using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppAlunos.Business.Models
{
    public class Disciplina : Entity
    {
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "nota_minima_aprovacao")]
        public double NotaMinimaAprovacao { get; set; }


        /* Relacionamento */
        [JsonIgnore]
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; set; }
    }
}
