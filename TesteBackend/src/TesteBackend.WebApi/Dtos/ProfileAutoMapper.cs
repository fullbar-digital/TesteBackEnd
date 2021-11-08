using AutoMapper;
using TesteBackend.Domain.Models;
using TesteBackend.WebApi.Dtos.AlunoDtos;
using TesteBackend.WebApi.Dtos.CursoDtos;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Dtos
{
    public class ProfileAutoMapper : Profile
    {
        /// <summary>
        /// Configuração de mapeamento das entidades para objetos de representação
        /// </summary>
        public ProfileAutoMapper()
        {
            /* DTOs Curso */
            CreateMap<CursoCreateDto, Curso>();
            CreateMap<Curso, CursoDto>();
            CreateMap<Curso, CursoFullDto>();
            CreateMap<CursoEditDto, Curso>();

            /* DTOs Disciplina */
            CreateMap<DisciplinaCreateDto, Disciplina>();
            CreateMap<Disciplina, DisciplinaDto>();
            CreateMap<Disciplina, DisciplinaFullDto>();

            /* DTOs Aluno */
            CreateMap<AlunoCreateDto, Aluno>();
            CreateMap<Aluno, AlunoDto>();
            CreateMap<AlunoEditDto, Aluno>();

            /* DTOs Matrícula em Disciplina */
            CreateMap<MatriculaCreateDto, Matricula>();
            CreateMap<Matricula, MatriculaDto>();
            CreateMap<MatriculaEditDto, Matricula>();
        }
    }
}
