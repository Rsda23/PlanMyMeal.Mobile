using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PlanMyMeal.Mobile.Extensions;
using Syncfusion.Maui.Core.Hosting;
using epj.RouteGenerator;

namespace PlanMyMeal.Mobile
{
    [AutoRoutes("Page")]
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder.Services.AddPlanMyMealViews();
            builder.Services.AddPlanMyMealViewModels();

            builder.Services.AddInfrastructure();

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
