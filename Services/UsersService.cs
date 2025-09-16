using PlanMyMeal.Domain.Models;
using PlanMyMeal_Domain.Interfaces;
using System.Diagnostics;
using System.Net.Http.Headers;
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
                var uri = $"GetUserByEmail?email={email}";
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
                var uri = $"PostUser";

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
                var uri = $"GetUserById?userId={userId}";
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

        public async Task<bool> UploadImage(string userId, FileResult image)
        {
            var uri = $"PostImage?userId={userId}";

            using var imageStream = await image.OpenReadAsync();
            var imageName = image.FileName;

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(imageStream);

            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(fileContent, "image", imageName);

            var response = await _httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseContent);
            var imageUrl = doc.RootElement.GetProperty("url").GetString();

            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }

            var putImage = await _httpClient.PutAsync($"Users/PutImage?userId={userId}&imageUrl={imageUrl}", null);


            return putImage.IsSuccessStatusCode;
        }
    }
}
