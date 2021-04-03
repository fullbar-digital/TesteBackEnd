using Flunt.Validations;
using App.Domain.Commands.Contracts;
using Flunt.Notifications;
using System;

public class DeleteStudentCommand : Notifiable, ICommand
{
    public DeleteStudentCommand()
    {

    }

    public DeleteStudentCommand(Guid Id)
    {
        this.Id = Id;
    }

    public Guid Id { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .HasMinLen(Id.ToString(), 3, "Name", "Name should have at least 3 chars")
        );
    }
}