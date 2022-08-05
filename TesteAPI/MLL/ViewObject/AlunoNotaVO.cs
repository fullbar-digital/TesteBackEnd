using Newtonsoft.Json;

namespace TesteAPI.MLL.ViewObject
{
    public class AlunoNotaVO
    {        

        [JsonProperty("nome_disciplina")]
        public string Disciplina_Nome { get; set; }

        [JsonProperty("nota")]
        public decimal Nota { get; set; }
    }
}
