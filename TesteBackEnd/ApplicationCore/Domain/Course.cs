using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Domain.Shared;

namespace ApplicationCore.Domain
{
    public class Course : Persist<Course, short>
    {
        /// <summary>
        ///     Recuper ou define nome
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public virtual string Name { get; set; }

        /// <summary>
        ///     Recupera ou define se esta ativo
        /// </summary>
        [Display(Name = "Ativo")]
        public virtual bool Active { get; set; }

        public IList<Student> Students { get; set; }

        protected override Course ConfigureValidation()
        {
            return this;
        }
    }
}