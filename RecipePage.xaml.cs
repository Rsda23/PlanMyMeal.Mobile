using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;

namespace PlanMyMeal_Domain;

public partial class RecipePage : ContentPage
{
	public RecipePage()
	{
		InitializeComponent();
	}
    private async void AddRecipe(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//AddRecipe");
	}
    private async void FilterButton(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new Filter());

        if (result != null)
        {
            ApplyFilter(result.ToString() ?? "Default");
        }
    }
    private void ApplyFilter(string category)
    {
        Console.WriteLine("Filtrage...");
    }
}