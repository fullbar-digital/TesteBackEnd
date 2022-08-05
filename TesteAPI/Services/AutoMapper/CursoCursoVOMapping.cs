using AutoMapper;

namespace TesteAPI.Services.AutoMapper
{
    public class CursoCursoVOMapping : Profile
    {
        public CursoCursoVOMapping()
        {
            CreateMap<MLL.Curso, MLL.ViewObject.CursoVO>()
               //.ForMember(dest => dest.Codigo, ori => ori.MapFrom(src => src.Codigo))
               .ForMember(dest => dest.Nome, ori => ori.MapFrom(src => src.Nome))
               ;

            CreateMap<MLL.ViewObject.CursoVO, MLL.Curso>();
        }
    }
}
