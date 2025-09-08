using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Services;

namespace PlanMyMeal_Domain.ViewModels
{

    public partial class LoginViewModel : ViewModelBase
    {
        private readonly UsersService _usersService;

        public LoginViewModel(UsersService usersService)
        {
            _usersService = usersService;
        }

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string error = string.Empty;
        [ObservableProperty]
        private bool isError = false;

        [ObservableProperty]
        private bool isVisible = true;


        [RelayCommand]
        private async Task NavigateTo(string destination)
        {
            if (string.IsNullOrEmpty(destination))
            {
                throw new Exception("La destination est vide ou null");
            }

            if (destination == "home")
            {
                await Shell.Current.GoToAsync("//Main");
            }
            else if (destination == "subscribe")
            {
                await Shell.Current.GoToAsync("//Subscribe");
            }
            else if (destination == "forgout")
            {
                await Shell.Current.GoToAsync("//Forgout");
            }
        }

        [RelayCommand]
        private async Task ValidLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                {
                    throw new Exception("Tous les champs doivent être remplis.");
                }

                User? user = await _usersService.GetUserByEmail(Email);

                if (user == null)
                {
                    Error = "Email ou mot de passe incorrect.";
                    IsError  = true;
                    return;
                }

                bool password = PasswordHashing.ConfirmPassword(Password, user.HashedPassword);

                if (!password)
                {
                    Error = "Email ou mot de passe incorrect.";
                    IsError = true;
                    return;
                }

                await NavigateTo("home");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                IsError = true;
            }
        }

        [RelayCommand]
        private void PasswordVisibility()
        {
            IsVisible = !IsVisible;
        }


        public void ResetVisibility()
        {
            IsError = false;
            Password = string.Empty;
            Email = string.Empty;
        }
    }
}
