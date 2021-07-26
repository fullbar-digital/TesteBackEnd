using student.manager.webapi.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.webapi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

        public static void ThrowIfNotEmpty(string message)
        {
            if (!message.IsNullOrEmpty())
                throw new NotFoundException(message);
        }
    }
}
