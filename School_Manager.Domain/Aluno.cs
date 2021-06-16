using System;

namespace School_Manager.Domain
{
    public class Aluno
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int RA { get; set; }
        public Curso Curso { get; set; }

        private bool status;
        public String Foto {get; set;}

        public void SetStatus(bool value)
        {
            status = value;
        }
        public bool GetStatus()
        {
            return status;
        }
    }
}