using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public abstract class Base
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}
