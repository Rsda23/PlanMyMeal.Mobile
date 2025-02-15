using BCrypt;

namespace PlanMyMeal.Mobile.Extensions
{
    public static class StringExtensions
    {
        public static string HashPassword(this string startPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(startPassword);
        }

        public static bool ConfirmPassword(this string startPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(startPassword, hashedPassword);
        }
    }
}
