using System.Text.RegularExpressions;

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
        try
        {
            bool verify = ConfirmedPseudo(PseudoEntry.Text);

            if (verify)
            {
                ErrorPseudo.IsVisible = false;
                Pseudo.IsVisible = false;
                Email.IsVisible = true;
                Password.IsVisible = false;
                await Task.Delay(500);
            }
        }
        catch (Exception ex)
        {
            ErrorPseudo.Text = ex.Message;
            ErrorPseudo.IsVisible = true;
        }
    }
    private async void Password_Next(object sender, EventArgs e)
    {
        try
        {
            bool verify = ConfirmedEmail(EmailEntry.Text);

            if (verify)
            {
                ErrorEmail.IsVisible = false;
                Pseudo.IsVisible = false;
                Email.IsVisible = false;
                Password.IsVisible = true;
                await Task.Delay(500);
            }
        }
        catch (Exception ex)
        {
            ErrorEmail.Text = ex.Message;
            ErrorEmail.IsVisible = true;
        }
    }
    private async void Btn_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

    public void Btn_Register(object sender, EventArgs e)
    {
        try
        {
            bool verify = VerifyPassword(FirstPasswordEntry.Text, ConfirmedPasswordEntry.Text);
            
            if (verify)
            {
                string inputPseudo = PseudoEntry.Text;
                string inputEmail = EmailEntry.Text;
                string hashedPassword = PasswordHashing.HashPassword(FirstPasswordEntry.Text);
                

                var newUser = new User
                {
                    Pseudo = inputPseudo,
                    Email = inputEmail,
                    HashedPassword = hashedPassword
                };

                var collection = _mongoDbService.GetCollection<User>("users");
                collection.InsertOne(newUser);

                Go_Main();
            }
        }
        catch (Exception ex)
        {
            ErrorPassword.Text = ex.Message;
            ErrorPassword.IsVisible = true;
        }

    }
    public bool VerifyPassword(string firstPassword, string secondPassword)
    {
        if (string.IsNullOrWhiteSpace(firstPassword) || string.IsNullOrWhiteSpace(secondPassword))
        {
            throw new Exception("Tous les champs doivent �tre remplis.");
        }

        if (firstPassword == secondPassword)
        {
            return ConfirmedPassword(firstPassword);
        }
        else
        {
            throw new Exception("Les mots de passe ne sont pas identique.");
        }
    }
    public bool ConfirmedPassword(string password)
    {

        if (password.Count() >= 8 && password.Count() <= 20)
        {
            return true;
        }
        else if (password.Count() > 20)
        {
            throw new Exception("Le mot de passe ne doit pas d�passer 20 caract�res.");
        }
        else
        {
            throw new Exception("Le mot de passe doit contenir au moins 8 caract�res.");
        }
    }
    public bool ConfirmedPseudo(string pseudo)
    {
        if (pseudo.Count() >= 3 && pseudo.Count() <= 20)
        {
            return true;
        }
        else if (pseudo.Count() > 20)
        {
            throw new Exception("Le pseudo ne doit pas d�passer 20 caract�res.");
        }
        else
        {
            throw new Exception("Le pseudo doit contenir au moins 3 caract�res.");
        }
    }
    public bool ConfirmedEmail(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (Regex.IsMatch(email, emailPattern))
        {
            return true;
        }
        else
        {
            throw new Exception("L'adresse email n'est pas valide.");
        }
    }
}