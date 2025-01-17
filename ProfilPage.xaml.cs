namespace PlanMyMeal_Domain;

public partial class ProfilPage : ContentPage
{
	public ProfilPage()
	{
		InitializeComponent();
	}
    private async void Btn_Setting(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Setting");
    }
    private async void Btn_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }
    public async void ChangeImage(object sender, EventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Selectionner une image"
        });

        if (result != null)
        {
            var flux = await result.OpenReadAsync();
            ProfilImage.Source = ImageSource.FromStream(() => flux);
        }
    }
    private void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        bool isDarkMode = e.Value;

        Application.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;
    }
    //private void OnThemeChanged(object sender, EventArgs e)
    //{
    //    var picker = (Picker)sender;
    //    var selectedTheme = picker.SelectedItem.ToString();

    //    // Changer le thème selon le choix
    //    switch (selectedTheme)
    //    {
    //        case "Clair":
    //            Application.Current.UserAppTheme = AppTheme.Light;
    //            break;
    //        case "Sombre":
    //            Application.Current.UserAppTheme = AppTheme.Dark;
    //            break;
    //        default:
    //            Application.Current.UserAppTheme = AppTheme.Unspecified;
    //            break;
    //    }
    //}
}