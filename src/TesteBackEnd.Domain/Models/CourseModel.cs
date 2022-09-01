using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Discipline;

namespace TesteBackEnd.Domain.Models
{
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DisciplineDto> Disciplines { get; set; }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

    }
}
