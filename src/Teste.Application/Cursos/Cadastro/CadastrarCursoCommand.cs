using MediatR;

namespace Teste.Application.Cursos.Cadastro
{
    public class CadastrarCursoCommand : IRequest<CadastrarCursoResponse>
    {
        public string Nome { get; set; } = default!;
    }
}
