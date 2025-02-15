namespace PlanMyMeal.Mobile;

public partial class PlanningPage : ContentPage
{
	public PlanningPage()
	{
        InitializeComponent();

        // Test de résolution DNS
        try
        {
            Console.WriteLine("Tentative de résolution DNS pour cluster0.nyfin.mongodb.net...");
            var hostEntry = System.Net.Dns.GetHostEntry("cluster0.nyfin.mongodb.net");
            Console.WriteLine("Résolution DNS réussie !");
            foreach (var ip in hostEntry.AddressList)
            {
                Console.WriteLine($"IP trouvée : {ip}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la résolution DNS : {ex.Message}");
        }
    }

}