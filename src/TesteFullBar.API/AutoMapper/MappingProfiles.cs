using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using TesteFullBar.API.ViewModels.Aluno;
using TesteFullBar.API.ViewModels.Aluno.Query;
using TesteFullBar.API.ViewModels.Curso;
using TesteFullBar.API.ViewModels.Disciplina;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Models.Dapper;

namespace TesteFullBar.API.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Aluno

            CreateMap<Aluno, AlunoViewModel>()
                .ReverseMap();

            CreateMap<AlunoQuery, AlunoQueryViewModel>()
               .ReverseMap();

            #endregion

            #region Curso

            CreateMap<Curso, CursoViewModel>()
                .ReverseMap();

            #endregion

            #region Disciplina

            CreateMap<Disciplina, DisciplinaViewModel>()
                .ReverseMap();

            #endregion
        }
    }
}
