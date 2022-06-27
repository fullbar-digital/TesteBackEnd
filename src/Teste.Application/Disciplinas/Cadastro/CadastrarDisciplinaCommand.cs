using MediatR;

namespace Teste.Application.Disciplinas.Cadastro
{
    public class CadastrarDisciplinaCommand : IRequest<CadastrarDisciplinaResponse>
    {
        public string Nome { get; set; } = default!;
        public decimal NotaMinimaAprovacao { get; set; }
        public string CursoId { get; set; } = default!;
    }
}
