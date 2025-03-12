using SmartAppointmentBackend.Models;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Repositories
{
    public interface IDoctorRepository
    {
        Task AddDoctorAsync(Doctor doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<Doctor> GetDoctorByNameAsync(string name);
        // Add more methods if needed later
    }
}
