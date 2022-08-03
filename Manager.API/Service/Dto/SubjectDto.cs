using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class SubjectDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int ApproveMin { get; set; }

        public SubjectDto() { }

        public SubjectDto(int code, string name, int approvemin)
        {
            Code = code;
            Name = name;
            ApproveMin = approvemin;
        }

    }
}
