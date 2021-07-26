using student.manager.webapi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.webapi.Infraestructure
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
