using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Curso
{
    public class CursoDescricaoViewModel
    {
        public CursoDescricaoViewModel()
        {

        }
        public CursoDescricaoViewModel(string descricao)
        {
            Descricao = descricao;
        }

        [FromRoute(Name = "descricao")]
        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string Descricao { get; set; }
    }
}
