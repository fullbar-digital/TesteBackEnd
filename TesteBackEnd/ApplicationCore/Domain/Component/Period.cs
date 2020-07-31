using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Domain.Component
{
    /// <summary>
    ///     Período
    /// </summary>
    public class Period
    {
        /// <summary>
        ///     Recupera ou define período inicial
        /// </summary>
        [Display(Name = "Início")]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     Recupera ou define período final
        /// </summary>
        [Display(Name = "Término")]
        public DateTime? End { get; set; }
    }
}