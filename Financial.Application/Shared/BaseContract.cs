using Flunt.Notifications;

namespace Financial.Application.Shared
{
    public abstract class BaseContract<Entity> : Notifiable<Notification> where Entity : class
    {
        protected abstract void Validate(Entity entity);
    }
}