using System;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Component;

namespace Api.Models
{
    /// <summary>
    ///     Request de Aluno
    /// </summary>
    public class StudentRequest
    {
        public string Name { get; set; }

        public string Ra { get; set; }

        public string InitialDate { get; set; }
        public string EndDate { get; set; }

        public decimal Grade { get; set; }

        public short CourseId { get; set; }

        /// <summary>
        ///     Converte o modelo para <see cref="Student" />
        /// </summary>
        /// <returns></returns>
        public Student ToObject(int id = 0)
        {
            return new Student
            {
                Id = id,
                CourseId = CourseId,
                Name = Name,
                Ra = Ra,
                Grade = Grade,
                Period = new Period
                {
                    Start = DateTime.ParseExact(InitialDate, "dd/MM/yyyy", null),
                    End = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null)
                },
                Status = Grade > 7
            };
        }
    }
}