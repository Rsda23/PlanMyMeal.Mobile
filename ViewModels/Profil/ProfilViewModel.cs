using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Interfaces;

namespace PlanMyMeal_Domain.ViewModels
{
    public partial class ProfilViewModel : ViewModelBase
    {
        private readonly IUsersService _usersService;
        public ProfilViewModel(IUsersService usersService) 
        {
            _usersService = usersService;
        }


        [ObservableProperty]
        private string image = string.Empty;

        [ObservableProperty]
        private string pseudo = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string userId = string.Empty;


        [RelayCommand]
        private async Task EditImage()
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Modifier l'image",
                "Souhaitez-vous vraiment modifier votre photo de profil ?",
                "Oui", "Non");

            if (!confirm)
            {
                return;
            }

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selectionner une image",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "image/*" } },
                    { DevicePlatform.iOS,     new[] { "public.image" } },
                    { DevicePlatform.WinUI,   new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".JPG", ".JPEG", ".PNG", ".GIF", ".BMP", ".WEBP" } }
                })
            });

            if (result == null)
            {
                return;
            }

            var success = await _usersService.UploadImage(UserId, result);
        }

        public async Task LoadUser()
        {
            IsRunning = true;
            IsLoaded = false;

            try
            {
                if (Preferences.ContainsKey("UserId"))
                {
                    string userId = Preferences.Get("UserId", string.Empty);
                    if (string.IsNullOrEmpty(userId))
                    {
                        throw new Exception("L'id de l'utilisateur est vide");
                    }

                    User? user = await _usersService.GetUserById(userId);

                    if (user != null)
                    {
                        Pseudo = user.Pseudo;
                        Email = user.Email;
                        UserId = user.UserId;
                    }
                    else
                    {
                        Pseudo = "Erreur";
                        Email = "Erreur";
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erreur", ex.Message, "fermer");
            }
            finally
            {
                IsLoaded = true;
                IsRunning = false;
            }
        }
    }
}
