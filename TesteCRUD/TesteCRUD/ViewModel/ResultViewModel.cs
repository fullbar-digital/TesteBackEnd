using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}
