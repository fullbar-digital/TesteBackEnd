using Newtonsoft.Json;
using System;

namespace TesteAPI.MLL
{
    public class Usuario
    {        
        public int Codigo { get; set; }

        public string Login { get; set; }
        
        public string Senha { get; set; }
       
        public DateTime Data_Criacao { get; set; }
    }
}
