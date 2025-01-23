namespace PlanMyMeal_Domain;

public partial class SubscribePage : ContentPage
{
    private readonly MongoDbService _mongoDbService;
    public SubscribePage(MongoDbService mongoDbService)
	{
		InitializeComponent();
        _mongoDbService = mongoDbService;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        PseudoEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        FirstPasswordEntry.Text = string.Empty;
        ConfirmedPasswordEntry.Text = string.Empty;

        Pseudo.IsVisible = true;
        Email.IsVisible = false;
        Password.IsVisible = false;
    }
    private async void Btn_Main(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Go_Main()
    {
        await Shell.Current.GoToAsync("//Main");
    }
    private async void Email_Next(object sender, EventArgs e)
    {
        Pseudo.IsVisible = false;
        Email.IsVisible = true;
        Password.IsVisible = false;
        await Task.Delay(500);
    }
    private async void Password_Next(object sender, EventArgs e)
    {
        Pseudo.IsVisible = false;
        Email.IsVisible = false;
        Password.IsVisible = true;
        await Task.Delay(500);
    }
    private async void Btn_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

    public void Btn_Register(object sender, EventArgs e)
    {
        string inputPseudo = PseudoEntry.Text;
        string inputEmail = EmailEntry.Text;

        string inputPassword = string.Empty;
        if (FirstPasswordEntry.Text == ConfirmedPasswordEntry.Text)
        {
            inputPassword = ConfirmedPasswordEntry.Text;
        }
        else
        {
            return;
        }

        var newUser = new User
        {
            Pseudo = inputPseudo,
            Email = inputEmail,
            HashedPassword = inputPassword
        };

        var collection = _mongoDbService.GetCollection<User>("users");
        collection.InsertOne(newUser);

        Go_Main();

    }
}