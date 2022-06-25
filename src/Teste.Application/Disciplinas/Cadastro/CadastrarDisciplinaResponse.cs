using System.Text.Json.Serialization;

namespace Teste.Application.Disciplinas.Cadastro
{
    public class CadastrarDisciplinaResponse
    {
        [JsonConstructor]
        public CadastrarDisciplinaResponse(Guid id)
        {
            Id = id.ToString();
        }

        public string Id { get; set; }
    }
}
