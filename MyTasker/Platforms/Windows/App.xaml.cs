using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyTasker.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

#if WINDOWS
            ToastNotificationManagerCompat.OnActivated += ToastNotificationManagerCompat_OnActivated;
#endif

        }

        private void ToastNotificationManagerCompat_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            // Handle notification activation
            if (e is ToastNotificationActivatedEventArgsCompat toastActivationArgs)
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastActivationArgs.Argument);

                // Obtain any user input (text boxes, menu selections) from the notification
                ValueSet userInput = toastActivationArgs.UserInput;
                string userArguments = toastActivationArgs.Argument;


                Console.WriteLine($"userInput = '{userInput.Keys.First()}' '{userInput.Values.First()}'");
                Console.WriteLine($"userArguments = '{userArguments}'");

            }
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    }

}
