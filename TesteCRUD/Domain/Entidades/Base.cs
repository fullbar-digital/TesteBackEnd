using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public abstract class Base
    {
        public long Codigo { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}
