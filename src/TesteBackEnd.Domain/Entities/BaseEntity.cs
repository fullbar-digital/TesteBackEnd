using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackEnd.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.UtcNow : value); }
        }
    }


    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
