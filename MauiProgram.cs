using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PlanMyMeal_Domain.Extensions;
using Syncfusion.Maui.Core.Hosting;

namespace PlanMyMeal_Domain
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddPlanMyMealModels();
            builder.Services.AddPlanMyMealView();
           
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
