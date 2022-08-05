using AutoMapper;
using TesteAPI.MLL.ViewObject;
using TesteAPI.MLL;

namespace TesteAPI.Services.AutoMapper
{
    public class DisciplinaDisciplinaVOMapping : Profile
    {
        public DisciplinaDisciplinaVOMapping()
        {
            CreateMap<MLL.Disciplina, MLL.ViewObject.DisciplinaVO>()              
              .ForMember(dest => dest.Nome, ori => ori.MapFrom(src => src.Nome))
              .ForMember(dest => dest.Nota_Aprovacao, ori => ori.MapFrom(src => src.Nota_Aprovacao))
              ;

            CreateMap<DisciplinaVO, Disciplina>();
        }
    }
}
