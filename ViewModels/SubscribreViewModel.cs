using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Interfaces;
using System.Text.RegularExpressions;

namespace PlanMyMeal_Domain.ViewModels
{
    public partial class SubscribreViewModel : ViewModelBase
    {
        private readonly IUsersService _userService;

        public SubscribreViewModel(IUsersService usersService)
        {
            _userService = usersService;
        }


        [ObservableProperty]
        public string pseudo = string.Empty;

        [ObservableProperty]
        public string email = string.Empty;

        [ObservableProperty]
        public string password = string.Empty;

        [ObservableProperty]
        public string secondPassword = string.Empty;

        [ObservableProperty]
        public bool isStepPseudo = true;

        [ObservableProperty]
        public bool isStepEmail = false;

        [ObservableProperty]
        public bool isStepPassword = false;

        [ObservableProperty]
        public bool isErrorPseudo = false;
        [ObservableProperty]
        public bool isErrorEmail = false;
        [ObservableProperty]
        public bool isErrorPassword = false;

        [ObservableProperty]
        public string errorPseudo = string.Empty;
        [ObservableProperty]
        public string errorEmail = string.Empty;
        [ObservableProperty]
        public string errorPassword = string.Empty;


        [RelayCommand]
        private async Task StepPseudo()
        {
            try
            {
                bool verify = ConfirmedPseudo(Pseudo);

                if (verify)
                {
                    IsErrorPseudo = false;
                    IsStepPseudo = false;
                    IsStepEmail = true;
                    IsStepPassword = false;
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                ErrorPseudo = ex.Message;
                IsErrorPseudo = true;
            }
        }

        [RelayCommand]
        private async Task StepEmail()
        {
            try
            {
                bool verify = await ConfirmedEmail(Email);

                if (verify)
                {
                    IsErrorEmail = false;
                    IsStepPseudo = false;
                    IsStepEmail = false;
                    IsStepPassword = true;
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {
                ErrorEmail = ex.Message;
                IsErrorEmail = true;
            }
        }

        [RelayCommand]
        public async Task StepPassword()
        {
            try
            {
                bool verify = VerifyPassword(Password, SecondPassword);

                if (verify)
                {
                    string hashedPassword = PasswordHashing.HashPassword(Password);

                    var newUser = new User
                    {
                        Pseudo = Pseudo,
                        Email = Email,
                        HashedPassword = hashedPassword
                    };

                    await _userService.PostUser(newUser);

                    await NavigateTo("home");
                }
            }
            catch (Exception ex)
            {
                ErrorPassword = ex.Message;
                IsErrorPassword = true;
            }

        }


        public bool VerifyPassword(string firstPassword, string secondPassword)
        {
            if (string.IsNullOrWhiteSpace(firstPassword) || string.IsNullOrWhiteSpace(secondPassword))
            {
                throw new Exception("Tous les champs doivent être remplis.");
            }

            if (firstPassword == secondPassword)
            {
                return ConfirmedPassword(firstPassword);
            }
            else
            {
                throw new Exception("Les mots de passe ne sont pas identique.");
            }
        }
       
        public bool ConfirmedPseudo(string pseudo)
        {
            if (string.IsNullOrWhiteSpace(pseudo))
            {
                throw new Exception("Tous les champs doivent être remplis.");
            }

            if (pseudo.Count() >= 3 && pseudo.Count() <= 20)
            {
                return true;
            }
            else if (pseudo.Count() > 20)
            {
                throw new Exception("Le pseudo ne doit pas dépasser 20 caractères.");
            }
            else
            {
                throw new Exception("Le pseudo doit contenir au moins 3 caractères.");
            }
        }

        public bool ConfirmedPassword(string password)
        {
            if (password.Count() >= 8 && password.Count() <= 20)
            {
                return true;
            }
            else if (password.Count() > 20)
            {
                throw new Exception("Le mot de passe ne doit pas dépasser 20 caractères.");
            }
            else
            {
                throw new Exception("Le mot de passe doit contenir au moins 8 caractères.");
            }
        }

        public async Task<bool> ConfirmedEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Tous les champs doivent être remplis.");
            }

            if (Regex.IsMatch(email, emailPattern))
            {
                User? user = await _userService.GetUserByEmail(email);
                if (user == null)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Cette adresse email est déjà utilisée.");
                }
            }
            else
            {
                throw new Exception("L'adresse email n'est pas valide.");
            }
        }

        public void ResetVisibility()
        {
            Pseudo = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            SecondPassword = string.Empty;

            IsStepPseudo = true;
            IsStepEmail = false;
            IsStepPassword = false;
        }
    }
}
