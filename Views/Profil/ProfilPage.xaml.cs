using PlanMyMeal_Domain.ViewModels;

namespace PlanMyMeal_Domain;

public partial class ProfilPage : ContentPage
{
    private readonly ProfilViewModel _profilViewModel;
	public ProfilPage(ProfilViewModel model)
	{
		InitializeComponent();
        _profilViewModel = model;
        BindingContext = _profilViewModel;
	}
    
    private void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        bool isDarkMode = e.Value;

        if (Application.Current != null)
        {
            Application.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _profilViewModel.LoadUser();
    }
}