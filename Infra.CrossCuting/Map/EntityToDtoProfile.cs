using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infra.CrossCuting.Map
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<AlunoDto, Aluno>()
                .ReverseMap();

            CreateMap<AlunoDtoUpdate, Aluno>()
                .ReverseMap();

            CreateMap<AlunoDtoCreate, Aluno>()
              .ReverseMap();
        }
    }
}