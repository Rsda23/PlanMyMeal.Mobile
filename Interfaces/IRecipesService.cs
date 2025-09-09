using PlanMyMeal.Domain.Models;

namespace PlanMyMeal_Domain.Interfaces
{
    public interface IRecipesService
    {
        public Task<List<Recipe>> GetRecipesByUserId(string userId);
    }
}
