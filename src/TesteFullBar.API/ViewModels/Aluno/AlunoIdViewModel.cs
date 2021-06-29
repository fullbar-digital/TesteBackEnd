using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TesteFullBar.API.ViewModels.Aluno
{
    public class AlunoIdViewModel
    {
        public AlunoIdViewModel()
        {

        }
        public AlunoIdViewModel(int id)
        {
            Id = id;
        }

        [FromRoute(Name = "id")]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
    }
}
