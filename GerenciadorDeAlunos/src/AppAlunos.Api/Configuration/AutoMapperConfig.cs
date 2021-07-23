using AutoMapper;
using AppAlunos.Business.Models;
using AppAlunos.Api.DTO;
using AppAlunos.Business.Models.Validations;

namespace AppAlunos.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Curso, CursoDTO>().ReverseMap();
            CreateMap<Disciplina, DisciplinaDTO>().ReverseMap();
            CreateMap<CursoDisciplina, CursoDisciplinaValidation>().ReverseMap();
        }

    }
}
