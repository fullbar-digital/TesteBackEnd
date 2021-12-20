using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Alunos : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string nome { get; set; }
        public virtual int ra { get; set; }
        public virtual string periodo { get; set; }
        public virtual int curso { get; set; }
        public virtual string status { get; }
        public virtual string foto { get; set; }

    }
}
