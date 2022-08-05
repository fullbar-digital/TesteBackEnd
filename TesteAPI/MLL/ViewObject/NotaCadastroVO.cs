using Newtonsoft.Json;
using System.Collections.Generic;

namespace TesteAPI.MLL.ViewObject
{
    public class NotaCadastroVO
    {

        [JsonProperty("ra_aluno")]
        public string RaAluno { get; set; }

        [JsonProperty("nota")]
        public List<AlunoNotaVO> Notas { get; set; }
    }
}
