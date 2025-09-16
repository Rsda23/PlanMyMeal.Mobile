using PlanMyMeal_Domain.ViewModels;

namespace PlanMyMeal_Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlanMyMealView(this IServiceCollection services)
        {
            services.AddTransient<MainPage>();
            services.AddTransient<LoginPage>();
            services.AddTransient<ForgoutPage>();
            services.AddTransient<SubscribePage>();
            services.AddTransient<ProfilPage>();
            services.AddTransient<PlanningPage>();
            services.AddTransient<RecipePage>();
            services.AddTransient<AddRecipePage>();
            services.AddTransient<Filter>();
            services.AddTransient<SettingPage>();

            return services;
        }

        public static IServiceCollection AddPlanMyMealModels(this IServiceCollection services)
        {
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SubscribreViewModel>();
            services.AddTransient<ProfilViewModel>();
            services.AddTransient<RecipeViewModel>();

            return services;
        }
    }
}
