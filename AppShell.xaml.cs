namespace PlanMyMeal_Domain
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddRecipePage), typeof(AddRecipePage));

            var userId = Preferences.Get("UserId", string.Empty);

            if (string.IsNullOrEmpty(userId))
            {
                GoToAsync("//Login");
            }
            else
            {
                GoToAsync("//Main");
            }
        }
    }
}
