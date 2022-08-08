using TesteBackEnd.Domain.Notifications;

namespace TesteBackEnd.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }

}