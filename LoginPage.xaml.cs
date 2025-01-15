using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace PlanMyMeal_Domain;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void Btn_Main(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Btn_Subscribe(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SubscribePage());
    }

    private async void Btn_Forgout(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgoutPage());
    }

}