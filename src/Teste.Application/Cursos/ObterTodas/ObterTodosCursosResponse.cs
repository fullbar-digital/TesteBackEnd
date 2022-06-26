using Teste.Application.Cursos.Dtos;

namespace Teste.Application.Cursos.ObterTodas
{
    public class ObterTodosCursosResponse
    {
        public ObterTodosCursosResponse(List<CursoDto> cursos)
        {
            Cursos = cursos;
        }

        public List<CursoDto> Cursos { get; set; } = new();
    }
}
