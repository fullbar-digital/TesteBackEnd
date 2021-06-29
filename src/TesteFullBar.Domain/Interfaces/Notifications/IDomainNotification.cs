using FluentValidation.Results;
using System.Collections.Generic;
using TesteFullBar.Domain.Models.Notifications;

namespace TesteFullBar.Domain.Interfaces.Notifications
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
        void AddNotifications(ValidationResult validationResult);
    }
}
