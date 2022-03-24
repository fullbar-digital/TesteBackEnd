using System.ComponentModel;
using System.Web.Http.Filters;

namespace Api.Filtros
{
    public class AlunosFilter : IFilter
    {

        public string Nome { get; set; }
        public string RA { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }

    }
}
