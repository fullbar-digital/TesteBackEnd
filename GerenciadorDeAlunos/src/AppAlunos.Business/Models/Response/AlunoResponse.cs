using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlunos.Business.Models.Response
{
    public class AlunoResponse
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string RegistroAcademico { get; set; }

        public string Periodo { get; set; }

        public string Foto { get; set; }

        public Guid CursoId { get; set; }

        public List<DisciplinaResponse> DadosDisciplina { get; set; }
    }
}
