using System;

namespace Domain.Dtos
{
    public class AlunoDtoUpdate
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}