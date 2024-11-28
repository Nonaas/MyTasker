using Microsoft.Toolkit.Uwp.Notifications;
using MyTasker.Domain.Services;
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
                // Obtain args from notification
                ToastArguments args = ToastArguments.Parse(toastActivationArgs.Argument);
                ValueSet userInput = toastActivationArgs.UserInput;

                if (args.TryGetValue("StartingPage", out string startingPage))
                {
                    // Set value in shared service
                    Services.GetRequiredService<NavigationService>()
                            .SetNavigationPageValue(startingPage);
                }

                
            }
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    }

}
