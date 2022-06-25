using AutoMapper;
using Teste.Application.Cursos.Alteracao;
using Teste.Application.Disciplinas.Alteracao;
using Teste.Application.Disciplinas.Cadastro;
using Teste.Application.Disciplinas.Dtos;
using Teste.Domain.Cursos.Entitites;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Application.MappingProfiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            //Disciplina
            CreateMap<CadastrarDisciplinaCommand, Disciplina>();
            CreateMap<AlterarDisciplinaCommand, Disciplina>()
                .ForMember(p => p.CursoId, opt => opt.MapFrom(src => new Guid(src.CursoId)))
                .ForMember(p => p.Id, opt => opt.MapFrom(src => new Guid(src.DisciplinaId)));
            CreateMap<Disciplina, DisciplinaDto>()
                .ForMember(p => p.Curso, opt => opt.MapFrom(src => src.Curso.Nome));

            CreateMap<AlterarCursoCommand, Curso>()
                .ForMember(p => p.Id, opt => opt.MapFrom(src => new Guid(src.CursoId)));
        }
    }
}
