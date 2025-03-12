using SmartAppointmentBackend.Models;

namespace SmartAppointmentBackend.Observers
{
    public interface IAppointmentSubject
    {
        void Attach(IAppointmentObserver observer);
        void Detach(IAppointmentObserver observer);
        void Notify(Appointment appointment);
    }
}
