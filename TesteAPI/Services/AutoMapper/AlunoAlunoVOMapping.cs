using AutoMapper;

namespace TesteAPI.Services.AutoMapper
{
    public class AlunoAlunoVOMapping : Profile
    {
        public AlunoAlunoVOMapping()
        {
            CreateMap<MLL.Aluno, MLL.ViewObject.AlunoVO>()
                .ForMember(dest => dest.Nome, ori => ori.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Periodo, ori => ori.MapFrom(src => src.Periodo))
                .ForMember(dest => dest.Status, ori => ori.MapFrom(src => src.Status))
                .ForMember(dest => dest.Nome_Curso, ori => ori.MapFrom(src => src.Curso.Nome))
                .ForMember(dest => dest.Registro_Academico, ori => ori.MapFrom(src => src.Registro_Academico))
                //.ForMember(dest => dest.Foto, ori => ori.MapFrom(src => src.Foto))
                //.ForMember(dest => dest.Notas, ori => ori.MapFrom(src => src.Notas));
                ;


            CreateMap<MLL.ViewObject.AlunoVO, MLL.Aluno>();

        }
    }
}
