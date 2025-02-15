using MongoDB.Driver;
using PlanMyMeal.Infrastructure;
using PlanMyMeal.Infrastructure.Models;
using PlanMyMeal.Mobile.Extensions;
using PlanMyMeal.Mobile.ViewModels;

namespace PlanMyMeal.Mobile;

public partial class LoginPage : ContentPage
{
    private readonly MongoDbService _mongoDbService;
    private bool _isPasswordVisible = false;
    private LoginViewModel _loginViewModel;
    public LoginPage(MongoDbService mongoDbService, LoginViewModel model)
	{
		InitializeComponent();
        _mongoDbService = mongoDbService;
        _loginViewModel = model;
        BindingContext = _loginViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        //EmailEntry.Text = string.Empty;
        ErrorLogin.IsVisible = false;

    }
    

    private async void ValidLogin(object sender, EventArgs e)
    {
        try
        {
            //string inputEmail = EmailEntry.Text;
            //string inputPassword = PasswordEntry.Text;
            //string emailConnected = inputEmail;
            //string token = AssignToken();

            var collection = _mongoDbService.GetCollection<User>("users");
            var user = collection.Find(user => user.Email == _loginViewModel.Email).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(_loginViewModel.Email) || string.IsNullOrWhiteSpace(_loginViewModel.Password))
            {
                throw new Exception("Tous les champs doivent être remplis.");
            }

            if (user == null)
            {
                ErrorLogin.Text = "Email ou mot de passe incorrect.";
                ErrorLogin.IsVisible = true;
                return;
            }

            bool password = _loginViewModel.Password.ConfirmPassword(user.HashedPassword);

            if (!password)
            {
                ErrorLogin.Text = "Email ou mot de passe incorrect.";
                ErrorLogin.IsVisible = true;
                return;
            }

            await Shell.Current.GoToAsync($"//{Routes.MainPage}");
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
    //private string AssignToken()
    //{
    //    string token = new
    //}
}