using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;

public class UpdateStudentrCommand : Notifiable, ICommand
    {
        public UpdateStudentrCommand()
        {
            
        }

        public UpdateStudentrCommand(Guid Id, string Name, string Register, string Period, string Status, string Photo, Guid CourseId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Register = Register;
            this.Period = Period;
            this.Photo = Photo;
            this.CourseId = CourseId;

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Register { get; set; }
        public string Period { get; set; }
        public string Photo { get; set; }
        public Guid CourseId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Name, 3, "Name", "Name should have at least 3 chars")
                .HasMinLen(Register, 3, "Register", "Register should have at least 3 chars")
                .HasMinLen(Period, 3, "Period", "Period should have at least 3 chars")
                .HasMinLen(Photo, 3, "Register", "Photo should have at least 3 chars")
            );
        }
    }