using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlanMyMeal.Mobile.ViewModels
{

    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;


        [RelayCommand]
        private async Task Subscribe()
        {
           await Shell.Current.GoToAsync($"//{Routes.SubscribePage}");
        }

        [RelayCommand]
        private async Task ForgetPassword()
        {
            await Shell.Current.GoToAsync($"//{Routes.ForgetPasswordPage}");
        }
    }
}
