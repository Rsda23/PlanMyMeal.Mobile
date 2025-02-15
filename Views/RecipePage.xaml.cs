using CommunityToolkit.Maui.Views;
using MongoDB.Driver;
using PlanMyMeal.Infrastructure;
using PlanMyMeal.Infrastructure.Models;

namespace PlanMyMeal.Mobile;

public partial class RecipePage : ContentPage
{
    private readonly MongoDbService _mongoService;
    public RecipePage(MongoDbService mongoService)
	{
        InitializeComponent();

        _mongoService = mongoService;
        LoadData();
    }
    private void LoadData()
    {
        var collection = _mongoService.GetCollection<User>("users");
        var data = collection.Find(_ => true).ToList();

        Console.WriteLine($"Nombre d'éléments récupérés : {data.Count}");
        RecipeListView.ItemsSource = data;
    }
    private async void AddRecipe(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{Routes.AddRecipePage}");
	}
    private async void FilterButton(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new ChooseMealPopup());

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