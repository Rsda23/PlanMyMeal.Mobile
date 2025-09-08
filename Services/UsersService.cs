using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Interfaces;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace PlanMyMeal_Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            try
            {
                var uri = $"Users/GetUserByEmail?email={email}";
                var response = await _httpClient.GetAsync(uri);
                var data = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(data);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("L'utilisateur est null");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> PostUser(User user)
        {
            try
            {
                var uri = $"Users/PostUser";

                var jsonContent = JsonSerializer.Serialize(user);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);
                var data = await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<User?> GetUserById(string userId)
        {
            try
            {
                var uri = $"Users/GetUserById?userId={userId}";
                var response = await _httpClient.GetAsync(uri);
                var data = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(data);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("L'utilisateur est null");
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
