using AutoMapper;
using Teste.Application.Alunos.Alteracao;
using Teste.Application.Alunos.Cadastro;
using Teste.Application.Alunos.Dtos;
using Teste.Application.Alunos.Filtro;
using Teste.Application.Cursos.Alteracao;
using Teste.Application.Cursos.Cadastro;
using Teste.Application.Cursos.Dtos;
using Teste.Application.Disciplinas.Alteracao;
using Teste.Application.Disciplinas.Cadastro;
using Teste.Application.Disciplinas.Dtos;
using Teste.Domain.Alunos.Dto;
using Teste.Domain.Alunos.Entities;
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
                .ForMember(p => p.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            CreateMap<Disciplina, DisciplinaDto>()
                .ForMember(p => p.Curso, opt => opt.MapFrom(src => src.Curso.Nome));

            //Curso
            CreateMap<CadastrarCursoCommand, Curso>();
            CreateMap<AlterarCursoCommand, Curso>()
                .ForMember(p => p.Id, opt => opt.MapFrom(src => new Guid(src.CursoId)));
            CreateMap<Curso, CursoDto>();

            //Aluno
            CreateMap<CadastrarAlunoCommand, Aluno>()
                .ForMember(p => p.RA, opt => opt.MapFrom(src => src.RegistroAcademico))
                .ForMember(p => p.Status, opt => opt.MapFrom(src => string.Empty))
                .ForMember(p => p.CursoId, opt => opt.MapFrom(src => new Guid(src.CursoId)));
            CreateMap<AlterarAlunoCommand, Aluno>()
                .ForMember(p => p.Id, opt => opt.MapFrom(src => new Guid(src.Id)))
                .ForMember(p => p.RA, opt => opt.MapFrom(src => src.RegistroAcademico))
                .ForMember(p => p.CursoId, opt => opt.MapFrom(src => new Guid(src.CursoId)));
            CreateMap<Aluno, AlunoDto>()
               .ForMember(p => p.Curso, opt => opt.MapFrom(src => src.Curso.Nome));

            CreateMap<FiltrarAlunoCommand, FilterAlunoDto>()
                .ForMember(p => p.Nome, opt => opt.MapFrom(src => src.Nome ?? string.Empty))
                .ForMember(p => p.RegistroAcademico, opt => opt.MapFrom(src => src.RegistroAcademico ?? string.Empty))
                .ForMember(p => p.Curso, opt => opt.MapFrom(src => src.Curso ?? string.Empty))
                .ForMember(p => p.Status, opt => opt.MapFrom(src => src.Status ?? string.Empty));


        }
    }
}
