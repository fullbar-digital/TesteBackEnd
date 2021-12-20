using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.MappingOverrides
{
    public class CadastroAlunos : IAutoMappingOverride<Alunos>
    {
        public void Override(AutoMapping<Alunos> mapping)
        {
        }
    }
}
