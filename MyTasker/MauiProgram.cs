using Microsoft.Extensions.Logging;

namespace MyTasker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("FreckleFace-Regular.ttf", "FreckleFace");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging
                .AddDebug()
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug);
            
#endif

            return builder.Build();
        }
    }
}
