using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Models;

namespace TesteBackEnd.Infrastructure.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<StudentModel, StudentDto>()
                .ReverseMap();
            CreateMap<StudentModel, StudentDtoCreate>()
                .ReverseMap();
            CreateMap<StudentModel, StudentDtoUpdate>()
                .ReverseMap();
            CreateMap<CourseModel, CourseDto>()
                .ReverseMap();
            CreateMap<CourseModel, CourseDtoCreate>()
                .ReverseMap();
            CreateMap<CourseModel, CourseDtoUpdate>()
               .ReverseMap();
            CreateMap<DisciplineModel, DisciplineDto>()
                .ReverseMap();
            CreateMap<DisciplineModel, DisciplineDtoCreate>()
                .ReverseMap();
            CreateMap<DisciplineModel, DisciplineDtoUpdate>()
               .ReverseMap();
            CreateMap<ScoreModel, ScoreDto>()
                .ReverseMap();
            CreateMap<ScoreModel, ScoreDtoCreate>()
                .ReverseMap();
            CreateMap<ScoreModel, ScoreDtoUpdate>()
                .ReverseMap();

        }
    }

}
