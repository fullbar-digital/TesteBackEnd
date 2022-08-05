using Newtonsoft.Json;
using System.Collections.Generic;

namespace TesteAPI.MLL.ViewObject
{
    public class AlunoVO
    {       

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("ra")]
        public string Registro_Academico { get; set; }

        [JsonProperty("periodo")]
        public string Periodo { get; set; }

        [JsonProperty("nome_curso")]
        public string Nome_Curso { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        //[JsonProperty("foto")]
        //public byte[] Foto { get; set; }

        //public List<AlunoNotaVO> Notas { get; set; }
    }
}
