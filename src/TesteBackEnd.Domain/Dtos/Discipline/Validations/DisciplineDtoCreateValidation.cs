using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TesteBackEnd.Domain.Dtos.Discipline.Validations
{
    public class DisciplineDtoCreateValidation : AbstractValidator<DisciplineDtoCreate>
    {
        public DisciplineDtoCreateValidation()
        {

        }
    }
}
