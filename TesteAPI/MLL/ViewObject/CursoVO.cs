using Newtonsoft.Json;
using System.Collections.Generic;

namespace TesteAPI.MLL.ViewObject
{
    public class CursoVO
    {      

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("disciplinas")]
        public List<MLL.ViewObject.DisciplinaVO> Disciplinas { get; set; }

    }
}
