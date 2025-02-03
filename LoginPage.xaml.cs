using Microsoft.Maui.ApplicationModel.Communication;
using MongoDB.Driver;

namespace PlanMyMeal_Domain;

public partial class LoginPage : ContentPage
{
    private readonly MongoDbService _mongoDbService;
    private bool _isPasswordVisible = false;
    public LoginPage(MongoDbService mongoDbService)
	{
		InitializeComponent();
        _mongoDbService = mongoDbService;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        EmailEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;

        ErrorLogin.IsVisible = false;

    }
    private async void Btn_Main(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Go_Main()
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Btn_Subscribe(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Subscribe");
    }

    private async void Btn_Forgout(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgoutPage());
    }
    private void ValidLogin(object sender, EventArgs e)
    {
        try
        {
            string inputEmail = EmailEntry.Text;
            string inputPassword = PasswordEntry.Text;
            string emailConnected = inputEmail;

            var collection = _mongoDbService.GetCollection<User>("users");
            var user = collection.Find(user => user.Email == inputEmail).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(inputEmail) || string.IsNullOrWhiteSpace(inputPassword))
            {
                throw new Exception("Tous les champs doivent �tre remplis.");
            }

            if (user == null)
            {
                ErrorLogin.Text = "Email ou mot de passe incorrect.";
                ErrorLogin.IsVisible = true;
                return;
            }

            bool password = PasswordHashing.ConfirmPassword(inputPassword, user.HashedPassword);

            if (!password)
            {
                ErrorLogin.Text = "Email ou mot de passe incorrect.";
                ErrorLogin.IsVisible = true;
                return;
            }

            Go_Main();
        }
        catch (Exception ex)
        {
            ErrorLogin.Text = ex.Message;
            ErrorLogin.IsVisible = true;
        }
    }
    private void PasswordVisibility(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        PasswordEntry.IsPassword = !_isPasswordVisible;
        if (_isPasswordVisible)
        {
            EyeYes.IsVisible = false;
            EyeNo.IsVisible = true;
        }
        else
        {
            EyeYes.IsVisible = true;
            EyeNo.IsVisible = false;
        }
    }
}