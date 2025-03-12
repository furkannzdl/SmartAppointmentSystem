using Microsoft.AspNetCore.Mvc;
using SmartAppointmentBackend.Services;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            var token = await _authService.RegisterUser(request.Username, request.Password, request.Role, request.Email);

            if (token == null)
                return BadRequest(new { message = "User already exists" });

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Username, request.Password);

            if (token == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { token });
        }
    }

    public class SignupRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Patient", "Doctor", "Admin"

        public string Email { get; set; } 
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
