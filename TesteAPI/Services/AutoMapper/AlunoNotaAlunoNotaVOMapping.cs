using AutoMapper;
using TesteAPI.MLL.ViewObject;
using TesteAPI.MLL;

namespace TesteAPI.Services.AutoMapper
{
    public class AlunoNotaAlunoNotaVOMapping : Profile
    {   

        public AlunoNotaAlunoNotaVOMapping()
        {
            CreateMap<MLL.AlunoNota, MLL.ViewObject.AlunoNotaVO>()
              .ForMember(dest => dest.Disciplina_Nome, ori => ori.MapFrom(src => src.Disciplina.Nome))
              .ForMember(dest => dest.Nota, ori => ori.MapFrom(src => src.Nota))
              ;

            CreateMap<AlunoNotaVO, AlunoNota>()              
                .ForMember(dest => dest.Nota, ori => ori.MapFrom(src => src.Nota));
            
        }       
       
    }
}
