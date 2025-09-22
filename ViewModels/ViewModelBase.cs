using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlanMyMeal_Domain.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private bool isRunning;

        [ObservableProperty]
        private bool isLoaded;

        [RelayCommand]
        public async Task NavigateTo(string destination)
        {
            if (string.IsNullOrEmpty(destination))
            {
                throw new Exception("La destination est vide ou null");
            }

            if (destination == "home")
            {
                await Shell.Current.GoToAsync("//Main");
            }
            else if (destination == "login")
            {
                await Shell.Current.GoToAsync("//Login");
            }
            else if (destination == "subscribe")
            {
                await Shell.Current.GoToAsync("//Subscribe");
            }
            else if (destination == "forgout")
            {
                await Shell.Current.GoToAsync("//Forgout");
            }
            else if (destination == "setting")
            {
                await Shell.Current.GoToAsync("Setting");
            }
            else if (destination == "addRecipe")
            {
                await Shell.Current.GoToAsync(nameof(AddRecipePage));
            }
        }
    }
}
