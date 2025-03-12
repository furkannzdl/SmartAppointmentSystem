using SmartAppointmentBackend.Models;
namespace SmartAppointmentBackend.Observers

{
    public interface IAppointmentObserver
    {
        void Update(Appointment appointment);
    }
}
