using PlanMyMeal_Domain.Interfaces;

namespace PlanMyMeal_Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
