using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Disciplina
{
    public class DisciplinaDescricaoViewModel
    {
        public DisciplinaDescricaoViewModel()
        {

        }
        public DisciplinaDescricaoViewModel(string descricao)
        {
            Descricao = descricao;
        }

        [FromRoute(Name = "descricao")]
        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string Descricao { get; set; }
    }
}
