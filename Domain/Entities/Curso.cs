using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Curso : IEntity
    {
        public int Id { get; set; }
        public string curso { get; set; }
        public int diciplinaCurso { get; set; }

    }
}
