using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace LouisApp
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
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<ViewModels.MonstersViewModel>();
            builder.Services.AddTransient<Pages.MonstersPage>();
            builder.Services.AddTransient<Pages.AddMonsterPage>();

            return builder.Build();
        }
    }
}
