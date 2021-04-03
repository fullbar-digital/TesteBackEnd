using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;
using App.Domain.Commands.Queries;

public class GetStudentsQuery: IQuery
    {
        public GetStudentsQuery()
        {
            
        }

        public GetStudentsQuery(string Name, string Register, string Period, string Status, Guid CourseId)
        {
            this.Name = Name;
            this.Register = Register;
            this.Period = Period;
            this.CourseId = CourseId;
            this.Status = Status;
        }

        public string Name { get; set; }
        public string Register { get; set; }
        public string Period { get; set; }
        public Guid CourseId { get; set; }
        public string Status { get; set; }

}