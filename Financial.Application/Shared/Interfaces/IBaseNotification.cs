using Flunt.Notifications;
using System.Collections.Generic;

namespace Financial.Application.Shared.Interfaces
{
    public interface IBaseNotification
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        bool IsValid { get; }
    }
}
