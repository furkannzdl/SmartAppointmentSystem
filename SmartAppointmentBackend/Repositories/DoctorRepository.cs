using SmartAppointmentBackend.Data;
using SmartAppointmentBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<Doctor> GetDoctorByNameAsync(string name)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
