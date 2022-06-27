using Teste.Application.Alunos.Dtos;

namespace Teste.Application.Alunos.ObterTodas
{
    public class ObterTodosAlunosResponse
    {
        public ObterTodosAlunosResponse(List<AlunoDto> alunos)
        {
            Alunos = alunos;
        }

        public List<AlunoDto> Alunos { get; set; } = new();
    }
}
