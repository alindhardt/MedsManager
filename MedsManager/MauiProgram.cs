using CommunityToolkit.Maui;
using MedsManager.Helpers;
using MedsManager.Services;
using Microsoft.Extensions.Logging;

namespace MedsManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands.otf", "FAB");
                    fonts.AddFont("fa-regular.otf", "FAR");
                    fonts.AddFont("fa-solid.otf", "FAS");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddMyServices();

            return builder.Build();
        }
    }
}
