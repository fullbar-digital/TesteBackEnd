using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using App.Domain.Models;

public class CreateSubjectCommand : Notifiable, ICommand
    {
        public CreateSubjectCommand()
        {
        }

        public CreateSubjectCommand(string Name, double MinAverageApproval)
        {
            this.Name = Name;
            this.MinAverageApproval = MinAverageApproval;
        }

        public string Name { get; set; }
        public double MinAverageApproval { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Name, 3, "Name", "Name should have at least 3 chars")
            );
        }
    }