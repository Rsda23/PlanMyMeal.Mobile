using System.Collections.ObjectModel;

namespace PlanMyMeal_Domain;

public partial class RecipePage : ContentPage
{
	public RecipePage()
	{
		InitializeComponent();
	}
    private async void AddRecipe(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync("//AddRecipe");
	}

	private void OnFilterClicked(Object sender, EventArgs e)
	{
        FilterPanel.IsVisible = !FilterPanel.IsVisible;

    }
}