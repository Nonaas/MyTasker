using MyTasker.Domain.Services.Interfaces;

namespace MyTasker.Platforms.Windows
{
    public class NotificationManagerService : INotificationManagerService
    {
        public event EventHandler NotificationReceived;

        public void ReceiveNotification(string title, string message) { }

        public void SendNotification(string title, string message, DateTime? notifyTime = null) { }
    }
}
