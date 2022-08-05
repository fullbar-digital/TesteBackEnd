using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro.AlunosAPI.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
    }
}
