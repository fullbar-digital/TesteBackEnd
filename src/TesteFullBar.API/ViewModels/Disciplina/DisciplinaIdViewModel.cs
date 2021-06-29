using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Disciplina
{
    public class DisciplinaIdViewModel
    {
        public DisciplinaIdViewModel()
        {

        }
        public DisciplinaIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
    }
}
