using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;

public class CreateStudentCommand : Notifiable, ICommand
    {
        public CreateStudentCommand()
        {
            
        }

        public CreateStudentCommand(string Name, string Register, string Period, string Status, string Photo)
        {
            this.Name = Name;
            this.Register = Register;
            this.Period = Period;
            this.Status = Status;
            this.Photo = Photo;
        }

        public string Name { get; set; }
        public string Register { get; set; }
        public string Period { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Name, 3, "Name", "Name should have at least 3 chars")
                .HasMinLen(Register, 3, "Register", "Register should have at least 3 chars")
                .HasMinLen(Period, 3, "Period", "Period should have at least 3 chars")
                .HasMinLen(Status, 3, "Status", "Status should have at least 3 chars")
                .HasMinLen(Photo, 3, "Register", "Photo should have at least 3 chars")
            );
        }
    }