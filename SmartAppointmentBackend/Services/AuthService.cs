using SmartAppointmentBackend.Factories;
using SmartAppointmentBackend.Repositories;
using SmartAppointmentBackend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SmartAppointmentBackend.Services
{
    public class AuthService
    {
        private readonly string _secretKey;
        private readonly IUserRepository _userRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AuthService(IUserRepository userRepository, IDoctorRepository doctorRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _doctorRepository = doctorRepository;
            _secretKey = configuration["Jwt:Key"];
        }


        public async Task<string> RegisterUser(string username, string password, string role, string email)
{
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser != null) return null;

            var user = UserFactory.CreateUser(username, password, role, email);
            await _userRepository.AddUserAsync(user);

            // Auto-create doctor if role is Doctor
            if (role == "Doctor")
            {
                var doctor = new Doctor
                {
                    Name = username,
                    Email = email, // Optional: make this dynamic or take from request
                    Specialization = "General Practitioner" 
                };

                // Save doctor to DB
                await _doctorRepository.AddDoctorAsync(doctor);
            }

            return GenerateToken(user);
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
