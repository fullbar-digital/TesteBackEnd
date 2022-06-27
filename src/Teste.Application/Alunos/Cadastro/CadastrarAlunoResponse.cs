using System.Text.Json.Serialization;

namespace Teste.Application.Alunos.Cadastro
{
    public class CadastrarAlunoResponse
    {
        [JsonConstructor]
        public CadastrarAlunoResponse(Guid id)
        {
            Id = id.ToString();
        }

        public string Id { get; set; }
    }
}
