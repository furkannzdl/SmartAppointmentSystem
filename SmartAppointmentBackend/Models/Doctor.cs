using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SmartAppointmentBackend.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; } // Örn: Kardiyolog, Ortopedist

        public ICollection<Appointment> Appointments { get; set; }
    }
}
