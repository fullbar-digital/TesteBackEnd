using System.ComponentModel.DataAnnotations;
using ApplicationCore.Domain.Component;
using ApplicationCore.Domain.Shared;
using FluentValidation;

namespace ApplicationCore.Domain
{
    public class Student : Persist<Student, int>
    {
        public Student()
        {
        }

        public Student(int id, short courseId, string name, string ra, Period period, decimal grade, bool status)
            : this()
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            Ra = ra;
            Period = period;
            Grade = grade;
            Status = status;
        }

        /// <summary>
        ///     Recupera ou define <see cref="Course" />
        /// </summary>
        public Course Course { get; set; }

        public short CourseId { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "RA (Registro acadêmico)")]
        public string Ra { get; set; }

        [Display(Name = "Período")] public Period Period { get; set; }

        [Display(Name = "Nota")] public decimal Grade { get; set; }
        [Display(Name = "Status")] public bool Status { get; set; }

        protected override Student ConfigureValidation()
        {
            Validator.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"O campo {DisplayName.Get<Student>(x => x.Name)} é obrigatório");

            Validator.RuleFor(x => x.Ra)
                .NotEmpty()
                .WithMessage($"O campo {DisplayName.Get<Student>(x => x.Ra)} é obrigatório");

            Validator.RuleFor(x => x.Grade)
                .NotEmpty()
                .WithMessage($"O campo {DisplayName.Get<Student>(x => x.Grade)} é obrigatório");

            return this;
        }
    }
}