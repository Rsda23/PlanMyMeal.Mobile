using BCrypt;

namespace PlanMyMeal_Domain;

public partial class SubscribePage : ContentPage
{
	public SubscribePage()
	{
		InitializeComponent();
	}
    private async void Btn_Main(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Btn_Next(object sender, EventArgs e)
    {
        Login.IsVisible = false;
        Password.IsVisible = true;
        await Task.Delay(500);
    }
    private async void Btn_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

    public void RegisterButton(object sender, EventArgs e)
    {
        string inputLogin = LoginEntry.Text;

    }
}