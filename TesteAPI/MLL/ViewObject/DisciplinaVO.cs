using Newtonsoft.Json;

namespace TesteAPI.MLL.ViewObject
{
    public class DisciplinaVO
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("nota_aprovacao")]
        public decimal Nota_Aprovacao { get; set; }
    }
}
