namespace PlanMyMeal_Domain
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Btn_Login(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }

        private void Label_Focused(object sender, FocusEventArgs e)
        {

        }
    }

}
