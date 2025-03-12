using SmartAppointmentBackend.Models;

namespace SmartAppointmentBackend.Factories
{
    public static class UserFactory
    {
        public static User CreateUser(string username, string password, string role, string email)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return role switch
            {
                "Patient" => new User { Username = username, PasswordHash = hashedPassword, Role = "Patient", Email = email },
                "Doctor" => new User { Username = username, PasswordHash = hashedPassword, Role = "Doctor", Email = email },
                "Admin" => new User { Username = username, PasswordHash = hashedPassword, Role = "Admin", Email = email},
                _ => throw new ArgumentException("Invalid user role")
            };
        }
    }
}
