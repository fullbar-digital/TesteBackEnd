using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Infrastructure.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<StudentEntity, StudentModel>()
                .ReverseMap();
            CreateMap<CourseEntity, CourseModel>()
                .ReverseMap();
            CreateMap<DisciplineEntity, DisciplineModel>()
                .ReverseMap();
            CreateMap<ScoreEntity, ScoreModel>()
               .ReverseMap();
        }
    }

}
