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
    public class CadastroAlunos : IAutoMappingOverride<Alunos>
    {
        public void Override(AutoMapping<Alunos> mapping) 
        {
        }
    }
}
