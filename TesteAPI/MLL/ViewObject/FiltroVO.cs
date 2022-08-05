using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TesteAPI.MLL.ViewObject
{
    public class FiltroVO
    {
        [Required]
        [JsonProperty("tipo_filtro")]
        //[EnumDataType(typeof(tpFiltro))]
        //[JsonConverter(typeof(StringEnumConverter))]
        public TpFiltro TipoFiltro { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }
    }

    //public enum tpFiltro
    //{       
    //    Nome = 1,        
    //    Ra = 2,        
    //    Curso = 3,        
    //    Status = 4
    //}
}
