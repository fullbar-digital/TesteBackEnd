using System;

namespace App.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}