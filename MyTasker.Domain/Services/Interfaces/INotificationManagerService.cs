namespace MyTasker.Domain.Services.Interfaces
{
    public interface INotificationManagerService
    {
        event EventHandler NotificationReceived;
        void SendNotification(string title, string message, DateTime? notifyTime = null, Dictionary<string, string>? args = null);
        void ReceiveNotification(string title, string message);
    }
}
