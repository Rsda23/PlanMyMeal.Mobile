using PlanMyMeal_Domain.ViewModels;

namespace PlanMyMeal_Domain;

public partial class RecipePage : ContentPage
{
    private readonly RecipeViewModel _recipeViewModel;
    public RecipePage(RecipeViewModel model)
	{
        InitializeComponent();

        _recipeViewModel = model;
        BindingContext = _recipeViewModel;
    }
}