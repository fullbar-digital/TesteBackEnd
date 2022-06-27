using System.Text.Json.Serialization;

namespace Teste.Application.Cursos.Cadastro
{
    public class CadastrarCursoResponse
    {
        [JsonConstructor]
        public CadastrarCursoResponse(Guid id)
        {
            Id = id.ToString();
        }

        public string Id { get; set; }
    }
}
