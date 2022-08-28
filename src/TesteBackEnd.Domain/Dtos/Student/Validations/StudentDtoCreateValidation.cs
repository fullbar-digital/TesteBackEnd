using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TesteBackEnd.Domain.Dtos.Student.Validations
{
    public class StudentDtoCreateValidation : AbstractValidator<StudentDtoCreate>
    {
        public StudentDtoCreateValidation()
        {

        }
    }
}
