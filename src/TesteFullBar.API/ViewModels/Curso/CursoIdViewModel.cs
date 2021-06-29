using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Curso
{
    public class CursoIdViewModel
    {
        public CursoIdViewModel()
        {

        }
        public CursoIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
    }
}
