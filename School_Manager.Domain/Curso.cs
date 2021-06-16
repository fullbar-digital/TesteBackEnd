using System;
using System.Collections.Generic;

namespace School_Manager.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public IEnumerable<Diciplina> Disciplinas { get; set; }   
    }
}