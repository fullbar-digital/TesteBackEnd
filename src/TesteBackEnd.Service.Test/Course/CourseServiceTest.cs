using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Course;

namespace TesteBackEnd.Service.Test.Course
{
    public class CourseServiceTest
    {
        public static Guid CourseId { get; set; }
        public static string Name { get; set; }
        public static string AlteredName { get; set; }
        public List<CourseDto> listCourseDto = new List<CourseDto>();
        public CourseDto courseDto;
        public CourseDtoCreate courseDtoCreate;
        public CourseDtoCreateResult courseDtoCreateResult;
        public CourseDtoUpdate courseDtoUpdate;
        public CourseDtoUpdateResult courseDtoUpdateResult;

        public CourseServiceTest()
        {
            CourseId = Guid.NewGuid();
            Name = Faker.Name.FullName();
            AlteredName = Faker.Name.FullName();


            for (int i = 0; i < 10; i++)
            {
                var dto = new CourseDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName()
                };
                listCourseDto.Add(dto);
            }

            courseDto = new CourseDto
            {
                Id = CourseId,
                Name = Name
            };

            courseDtoCreate = new CourseDtoCreate
            {
                Name = Name
            };

            courseDtoCreateResult = new CourseDtoCreateResult
            {
                Id = CourseId,
                Name = Name
            };

            courseDtoUpdate = new CourseDtoUpdate
            {
                Name = AlteredName
            };

            courseDtoUpdateResult = new CourseDtoUpdateResult
            {
                Id = CourseId,
                Name = AlteredName,
            };
        }
    }
}
