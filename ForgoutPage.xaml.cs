namespace PlanMyMeal_Domain;

public partial class ForgoutPage : ContentPage
{
	public ForgoutPage()
	{
		InitializeComponent();
	}
    private async void Btn_Mail(object sender, EventArgs e)
    {
        Mail.IsVisible = false;
        Code.IsVisible = true;
        Password.IsVisible = false;
        await Task.Delay(500);
    }
    private async void Btn_Password(object sender, EventArgs e)
    {
        Mail.IsVisible = false;
        Code.IsVisible = false;
        Password.IsVisible = true;
        await Task.Delay(500);
    }
    private async void Btn_Main(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Btn_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }
}