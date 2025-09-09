using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace PlanMyMeal_Domain.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly HttpClient _httpClient;
        public RecipesService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<List<Recipe>> GetRecipesByUserId(string userId)
        {
            try
            {
                var uri = $"Recipes/GetRecipesByUserId?userId={userId}";
                var response = await _httpClient.GetAsync(uri);
                var data = await response.Content.ReadAsStringAsync();
                var recipes = JsonSerializer.Deserialize<List<Recipe>>(data);
                if (recipes != null)
                {
                    return recipes;
                }
                else
                {
                    throw new Exception("Les recettes sont null");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
    }
}
