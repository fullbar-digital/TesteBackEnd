using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Model
{
    public class ModelResult
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

    }
}
