using PlanMyMeal.Domain.Models;

namespace PlanMyMeal_Domain.Interfaces
{
    public interface IUsersService
    {
        public Task<User?> GetUserByEmail(string email);
        public Task<bool> PostUser(User user);
        public Task<User?> GetUserById(string userId);
        public Task<bool> UploadImage(string userId, FileResult image);
    }
}
