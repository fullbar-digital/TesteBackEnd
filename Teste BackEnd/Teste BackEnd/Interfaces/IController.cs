using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_BackEnd.Interfaces
{
    public interface IController<T>
    {
        void Add([FromBody] T value);
    }
}
