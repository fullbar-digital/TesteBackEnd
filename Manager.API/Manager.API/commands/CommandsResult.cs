using Manager.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.commands
{
    public class CommandsResult
    {
        public static ModelResult ApplicationErrorMessage(Exception ex)
        {
            return new ModelResult
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Error = ex.Message,
                Success = false,
                //Date = null
            };
        }

        public static ModelResult DomainErrorMessage(string message)
        {
            return new ModelResult
            {
                Message = message,
                Success = false,
                
            };
        }

        public static ModelResult DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ModelResult
            {
                Message = message,
                Success = false,
                
            };
        }

    }
}
