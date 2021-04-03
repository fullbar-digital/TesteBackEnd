using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using App.Domain.Models;

public class CreateCourseCommand : Notifiable, ICommand
    {
        public CreateCourseCommand()
        {
            this.Subjects = new List<Subject>();
        }

        public CreateCourseCommand(string Name, List<Subject> Subjects)
        {
            this.Name = Name;
            this.Subjects = Subjects;
        }

        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Name, 3, "Name", "Name should have at least 3 chars")
            );
        }
    }