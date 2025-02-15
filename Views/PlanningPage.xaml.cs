namespace PlanMyMeal.Mobile;

public partial class PlanningPage : ContentPage
{
	public PlanningPage()
	{
        InitializeComponent();

        // Test de r�solution DNS
        try
        {
            Console.WriteLine("Tentative de r�solution DNS pour cluster0.nyfin.mongodb.net...");
            var hostEntry = System.Net.Dns.GetHostEntry("cluster0.nyfin.mongodb.net");
            Console.WriteLine("R�solution DNS r�ussie !");
            foreach (var ip in hostEntry.AddressList)
            {
                Console.WriteLine($"IP trouv�e : {ip}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la r�solution DNS : {ex.Message}");
        }
    }

}