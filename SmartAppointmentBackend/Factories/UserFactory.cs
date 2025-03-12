using SmartAppointmentBackend.Models;

namespace SmartAppointmentBackend.Factories
{
    public static class UserFactory
    {
        public static User CreateUser(string username, string password, string role)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return role switch
            {
                "Patient" => new User { Username = username, PasswordHash = hashedPassword, Role = "Patient" },
                "Doctor" => new User { Username = username, PasswordHash = hashedPassword, Role = "Doctor" },
                "Admin" => new User { Username = username, PasswordHash = hashedPassword, Role = "Admin" },
                _ => throw new ArgumentException("Invalid user role")
            };
        }
    }
}
