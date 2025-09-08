using PlanMyMeal_Domain.ViewModels;

namespace PlanMyMeal_Domain;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _loginViewModel;
    public LoginPage(LoginViewModel model)
	{
		InitializeComponent();
        _loginViewModel = model;
        BindingContext = _loginViewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _loginViewModel.ResetVisibility();
    }
}