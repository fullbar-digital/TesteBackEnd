using AutoMapper;
using Cadastro.AlunosAPI.Data.ValueObject;
using Cadastro.AlunosAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<AlunoVO, Alunos>();
                config.CreateMap<Alunos, AlunoVO>();
            });
            return mappingConfig;
        }
    }
}
