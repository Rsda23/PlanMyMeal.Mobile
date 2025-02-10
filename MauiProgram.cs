using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PlanMyMeal.Infrastructure;
using Syncfusion.Maui.Core.Hosting;

namespace PlanMyMeal_Domain
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<MongoDbService>();
            builder.Services.AddTransient<RecipePage>();
            builder.Services.AddTransient<SubscribePage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ProfilPage>();
            builder.ConfigureSyncfusionCore();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
