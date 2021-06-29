using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Aluno
{
    public class AlunoRaViewModel
    {
        public AlunoRaViewModel()
        {

        }
        public AlunoRaViewModel(string ra)
        {
            Ra = ra;
        }

        [FromRoute(Name = "ra")]
        [Required(ErrorMessage = "Ra é obrigatório")]
        public string Ra { get; set; }
    }
}
