using Microsoft.Toolkit.Uwp.Notifications;
using MyTasker.Domain.Services.Interfaces;

namespace MyTasker.Platforms.Windows
{
    public class NotificationManagerService : INotificationManagerService
    {
        public event EventHandler NotificationReceived;
        public void ReceiveNotification(string title, string message) { }


        public void SendNotification(string title, string message, DateTime? notifyTime = null, Dictionary<string, string>? args = null)
        {
            ToastContentBuilder msToast = InitToastContent(title, message);

            SetNotificationArgs(args, msToast);

            SetNotificationSchedule(notifyTime, msToast);
        }

        private static ToastContentBuilder InitToastContent(string title, string message)
        {
            ToastContentBuilder msToast = new();
            msToast.AddText(title)
                   .AddText(message);

            return msToast;
        }

        private static void SetNotificationSchedule(DateTime? notifyTime, ToastContentBuilder msToast)
        {
            if (notifyTime != null)
            {
                DateTimeOffset deliveryTime = notifyTime.Value;

                // Schedule toast
                msToast.Schedule(deliveryTime);
            }
            else
            {
                // Display toast now
                msToast.Show();
            }
        }

        private static void SetNotificationArgs(Dictionary<string, string>? dynamicArguments, ToastContentBuilder msToast)
        {
            // Add arguments if provided
            if (dynamicArguments != null)
            {
                foreach (KeyValuePair<string,string> arg in dynamicArguments)
                {
                    msToast.AddArgument(arg.Key, arg.Value);
                }
            }
        }


    }
}