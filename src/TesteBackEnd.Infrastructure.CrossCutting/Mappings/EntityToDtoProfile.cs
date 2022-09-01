using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<StudentDto, StudentEntity>()
                .ReverseMap();
            CreateMap<StudentDtoCreateResult, StudentEntity>()
                .ReverseMap();
            CreateMap<StudentDtoUpdateResult, StudentEntity>()
                .ReverseMap();

            CreateMap<CourseDto, CourseEntity>()
                .ReverseMap();
            CreateMap<CourseDtoCreateResult, CourseEntity>()
                .ReverseMap();
            CreateMap<CourseDtoUpdateResult, CourseEntity>()
                .ReverseMap();

            CreateMap<DisciplineDto, DisciplineEntity>()
               .ReverseMap();
            CreateMap<DisciplineDtoCreateResult, DisciplineEntity>()
                .ReverseMap();
            CreateMap<DisciplineDtoUpdateResult, DisciplineEntity>()
                .ReverseMap();

            CreateMap<ScoreDto, ScoreEntity>()
               .ReverseMap();
            CreateMap<ScoreDtoCreateResult, ScoreEntity>()
                .ReverseMap();
            CreateMap<ScoreDtoUpdateResult, ScoreEntity>()
                .ReverseMap();
        }
    }

}
