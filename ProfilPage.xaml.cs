using PlanMyMeal.Infrastructure;

namespace PlanMyMeal_Domain;

public partial class ProfilPage : ContentPage
{
    private MongoDbService _mongoDbService;
	public ProfilPage(MongoDbService mongoDbService)
	{
		InitializeComponent();
        _mongoDbService = mongoDbService;
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

        if (Application.Current != null)
        {
            Application.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;
        }
    }
    //private void RecoverText(object sender, EventArgs e)
    //{

    //    string emailConnected = 
    //    var collection = _mongoDbService.GetCollection<User>("users");
    //    var user = collection.Find(user => user.Email == email);
    //}
    
}