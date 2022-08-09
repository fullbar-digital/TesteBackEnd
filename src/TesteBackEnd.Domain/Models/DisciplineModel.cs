using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackEnd.Domain.Models
{
    public class DisciplineModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public decimal MinimalScore { get; set; }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

    }
}
