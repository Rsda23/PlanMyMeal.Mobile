using PlanMyMeal.Infrastructure;
using PlanMyMeal.Mobile.ViewModels;

namespace PlanMyMeal.Mobile.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlanMyMealViews(this IServiceCollection services)
        {
            services.AddTransient<RecipePage>();
            services.AddTransient<SubscribePage>();
            services.AddTransient<LoginPage>();
            services.AddTransient<ProfilPage>();
            return services;
        }

        public static IServiceCollection AddPlanMyMealViewModels(this IServiceCollection services)
        {
            services.AddTransient<LoginViewModel>();
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbService>();
            return services;
        }
    }
}
