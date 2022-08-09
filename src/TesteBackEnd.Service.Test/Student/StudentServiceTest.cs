using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Student;

namespace TesteBackEnd.Service.Test.Student
{
    public class StudentServiceTest
    {
        public static Guid StudentId { get; set; }
        public static string Name { get; set; }
        public static string AlteredName { get; set; }
        public static string AcademicRecord { get; set; }
        public static string AlteredAcademicRecord { get; set; }
        public static string Period { get; set; }
        public static string AlteredPeriod { get; set; }
        public static string Photo { get; set; }
        public static string AlteredPhoto { get; set; }
        public List<StudentDto> listStudentDto = new List<StudentDto>();
        public StudentDto studentDto;
        public StudentDtoCreate studentDtoCreate;
        public StudentDtoCreateResult studentDtoCreateResult;
        public StudentDtoUpdate studentDtoUpdate;
        public StudentDtoUpdateResult studentDtoUpdateResult;

        public StudentServiceTest()
        {
            StudentId = Guid.NewGuid();
            Name = Faker.Name.FullName();
            AlteredName = Faker.Name.FullName();
            AcademicRecord = "123456";
            AlteredAcademicRecord = "654321";
            Photo = "photo.jpg";
            AlteredPhoto = "photo.png";
            Period = "2022.1";
            AlteredPeriod = "2022.2";


            for (int i = 0; i < 10; i++)
            {
                var dto = new StudentDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName()
                };
                listStudentDto.Add(dto);
            }

            studentDto = new StudentDto
            {
                Id = StudentId,
                Name = Name,
                AcademicRecord = AcademicRecord,
                Photo = Photo,
                Period = Period
            };

            studentDtoCreate = new StudentDtoCreate
            {
                Name = Name,
                AcademicRecord = AcademicRecord,
                Photo = Photo,
                Period = Period
            };

            studentDtoCreateResult = new StudentDtoCreateResult
            {
                Id = StudentId,
                Name = Name,
                AcademicRecord = AcademicRecord,
                Photo = Photo,
                Period = Period
            };

            studentDtoUpdate = new StudentDtoUpdate
            {
                Name = AlteredName,
                AcademicRecord = AcademicRecord,
                Photo = Photo,
                Period = Period
            };

            studentDtoUpdateResult = new StudentDtoUpdateResult
            {
                Name = AlteredName,
                AcademicRecord = AcademicRecord,
                Photo = Photo,
                Period = Period
            };
        }
    }
}
