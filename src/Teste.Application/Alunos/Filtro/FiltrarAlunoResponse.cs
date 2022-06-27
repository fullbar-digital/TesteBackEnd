using Teste.Application.Alunos.Dtos;

namespace Teste.Application.Alunos.Filtro
{
    public class FiltrarAlunoResponse
    {
        public FiltrarAlunoResponse(List<AlunoDto> alunos)
        {
            Alunos = alunos;
        }

        public List<AlunoDto> Alunos { get; set; } = new();
    }
}
