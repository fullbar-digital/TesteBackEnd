using Newtonsoft.Json;

namespace TesteAPI.MLL.ViewObject
{
    public class UsuarioVO
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
