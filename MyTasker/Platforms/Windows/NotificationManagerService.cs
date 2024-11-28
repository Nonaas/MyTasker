using Microsoft.Toolkit.Uwp.Notifications;
using MyTasker.Domain.Services.Interfaces;

namespace MyTasker.Platforms.Windows
{
    public class NotificationManagerService : INotificationManagerService
    {
        public event EventHandler NotificationReceived;
        public void ReceiveNotification(string title, string message) { }

        public void SendNotification(string title, string message, DateTime? notifyTime = null) 
        {
            // Construct content
            ToastContentBuilder msToast = new();
            msToast.AddArgument("action", "viewItemsDueToday")
                   .AddText(title)
                   .AddText(message);

            if (notifyTime != null)
            {
                DateTimeOffset deliveryTime = notifyTime.Value;

                // Schedule toast
                msToast.Schedule(deliveryTime);
            }
            else
            {
                // Display toast
                msToast.Show();
            }
        }

    }
}
