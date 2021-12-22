using Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MappingOverrides
{
    public class CadastroCurso : IAutoMappingOverride<Curso>
    {
        public void Override(AutoMapping<Curso> mapping) 
        {
        }

    }
}
