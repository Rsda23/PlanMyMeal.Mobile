namespace PlanMyMeal_Domain
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddRecipePage), typeof(AddRecipePage));
        }
    }
}
