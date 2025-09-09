using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PlanMyMeal_Domain.Extensions;
using PlanMyMeal_Domain.Interfaces;
using PlanMyMeal_Domain.Services;
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

            builder.Services.AddHttpClient<IUsersService, UsersService>(client =>
            {
                client.BaseAddress = new Uri("#lien azure");
            });

            builder.Services.AddHttpClient<IRecipesService, RecipesService>(client =>
            {
                client.BaseAddress = new Uri("#lien azure");
            });

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
