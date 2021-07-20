using System.Collections.Generic;

namespace url.business.Notifications
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}