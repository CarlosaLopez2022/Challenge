using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Challenge.ViewModels;
using Challenge.Services.Abstractions;
using Challenge.Services;

namespace Challenge
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
                });
            builder.Services.AddTransientWithShellRoute<MainPage, MainPageViewModel>(nameof(MainPage));
            builder.Services.AddTransientWithShellRoute<DetailsPage,DetailsPageViewModel>(nameof(DetailsPage));
            builder.Services.AddSingleton<IWeatherService, WeatherService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
