using PlanMyMeal.Domain.Models;

namespace PlanMyMeal_Domain.Interfaces
{
    public interface IUsersService
    {
        public Task<User?> GetUserByEmail(string email);
    }
}
