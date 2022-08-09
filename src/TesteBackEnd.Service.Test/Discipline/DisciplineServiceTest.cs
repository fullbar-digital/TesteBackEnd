using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Discipline;

namespace TesteBackEnd.Service.Test.Discipline
{
    public class DisciplineServiceTest
    {
        public static Guid DisciplineId { get; set; }
        public static Guid CourseId { get; set; }
        public static Guid AlteredCourseId { get; set; }
        public static string Name { get; set; }
        public static string AlteredName { get; set; }
        public static decimal MinimalScore { get; set; }
        public static decimal AlteredMinimalScore { get; set; }
        public List<DisciplineDto> listDisciplineDto = new List<DisciplineDto>();
        public DisciplineDto disciplineDto;
        public DisciplineDtoCreate disciplineDtoCreate;
        public DisciplineDtoCreateResult disciplineDtoCreateResult;
        public DisciplineDtoUpdate disciplineDtoUpdate;
        public DisciplineDtoUpdateResult disciplineDtoUpdateResult;

        public DisciplineServiceTest()
        {
            DisciplineId = Guid.NewGuid();
            CourseId = Guid.NewGuid();
            AlteredCourseId = Guid.NewGuid();
            Name = "Discipline Name";
            AlteredName = "Altered Discipline Name";
            MinimalScore = 7;
            AlteredMinimalScore = 7;


            for (int i = 0; i < 10; i++)
            {
                var dto = new DisciplineDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Discipline Name",
                    MinimalScore = 7,
                    CourseId = Guid.NewGuid()
                };
                listDisciplineDto.Add(dto);
            }

            disciplineDto = new DisciplineDto
            {
                Id = DisciplineId,
                Name = Name,
                MinimalScore = MinimalScore,
                CourseId = CourseId
            };

            disciplineDtoCreate = new DisciplineDtoCreate
            {
                Name = Name,
                MinimalScore = MinimalScore,
                CourseId = CourseId
            };

            disciplineDtoCreateResult = new DisciplineDtoCreateResult
            {
                Id = DisciplineId,
                Name = Name,
                MinimalScore = 7,
                CourseId = CourseId
            };

            disciplineDtoUpdate = new DisciplineDtoUpdate
            {
                Id = DisciplineId,
                Name = AlteredName,
                MinimalScore = AlteredMinimalScore,
                CourseId = AlteredCourseId
            };

            disciplineDtoUpdateResult = new DisciplineDtoUpdateResult
            {
                Id = DisciplineId,
                Name = AlteredName,
                MinimalScore = AlteredMinimalScore,
                CourseId = AlteredCourseId
            };
        }
    }
}
