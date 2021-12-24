using System;
using System.Collections.Generic;

namespace Web.Api.ViewModels
{
    public class StudentApivm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ra { get; set; }
        public int Period { get; set; }
        public string ProfilePicture { get; set; }
        public string Course { get; set; }
        public string Status { get; set; }

        public List<SchoolReportApivm> SchoolReports { get; set; }
    }
}
