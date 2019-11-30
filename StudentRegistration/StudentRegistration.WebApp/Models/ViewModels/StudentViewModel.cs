using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.WebApp.Models.ViewModels
{
    public class StudentViewModel
    {
        public int ID { get; set; }

        [Display(Name = "RA")]
        [Required(ErrorMessage = "O {0} é o obrigatório.")]
        public int AR { get; set; }

        [Display(Name = "Nome do Aluno")]
        [Required(ErrorMessage = "O {0} é o obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Período")]
        [Required(ErrorMessage = "O {0} é o obrigatório.")]
        public int Period { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "O {0} é o obrigatório.")]
        public int Course { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "A {0} é o obrigatória.")]
        [Range(0.0, 10.0, ErrorMessage = "Entre com uma nota válida (entre 0 e {0})")]
        public double Grade { get; set; }

        public int Status { get; set; }

        public SelectList StudentCourses { get; set; }

        public SelectList StudentPeriods { get; set; }

        public string DisplayPeriod { get; set; }

        public string DisplayCourse { get; set; }

        public string DisplayStatus { get; set; }
    }
}
