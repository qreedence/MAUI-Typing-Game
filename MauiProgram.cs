using MAUIEden.Services;
using MAUIEden.Utilities;
using MAUIEden.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUIEden
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("PassionOne-Regular.ttf", "PassionOne");
                    fonts.AddFont("PassionOne-Bold.ttf", "PassionOneBold");
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<GamePage>();
            builder.Services.AddTransient<EndScreenPage>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<GameViewModel>();
            builder.Services.AddTransient<EndScreenViewModel>();

            builder.Services.AddTransient<RandomWordService>();
            builder.Services.AddTransient<GameState>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
