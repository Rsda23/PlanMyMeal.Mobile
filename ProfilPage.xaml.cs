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
}