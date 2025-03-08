using System.ComponentModel.DataAnnotations;

namespace SmartAppointmentBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Hashed password

        [Required]
        public string Role { get; set; } // "Patient", "Doctor", "Admin"
    }
}
