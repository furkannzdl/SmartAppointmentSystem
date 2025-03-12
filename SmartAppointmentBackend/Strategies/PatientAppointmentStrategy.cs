using SmartAppointmentBackend.Models;
using SmartAppointmentBackend.Repositories;
using System.Threading.Tasks;


namespace SmartAppointmentBackend.Strategies
{
    public class PatientAppointmentStrategy : IAppointmentStrategy
    {
        private readonly IAppointmentRepository _repository;

        public PatientAppointmentStrategy(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> BookAppointment(Appointment appointment)
        {
            // Check if appointment slot is available
           var existingAppointments = await _repository.GetAppointmentsAsync();
            if (existingAppointments.Any(a => a.AppointmentDate == appointment.AppointmentDate && a.DoctorId == appointment.DoctorId))
                return false;


            await _repository.AddAppointmentAsync(appointment);
            return true;
        }
    }
}
