using CommunityToolkit.Mvvm.Input;
using PlanMyMeal_Domain.Interfaces;

namespace PlanMyMeal_Domain.ViewModels
{
    public partial class RecipeViewModel : ViewModelBase
    {
        private readonly IRecipesService _recipesService;
        public RecipeViewModel(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }


        [RelayCommand]
        private async Task Filter()
        {

        }


        private async Task DisplayRecipe()
        {
           
        }
    }
}
