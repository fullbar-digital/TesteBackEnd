using AutoMapper;
using Fullbar.Teste.Api.ViewModels;
using Fullbar.Teste.Domain.Entities;

namespace Fullbar.Teste.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Disciplina, DisciplinaViewModel>().ReverseMap();
        }
    }
}