using SmartAppointmentBackend.Models;

namespace SmartAppointmentBackend.Observers
{
    public class AppointmentSubject : IAppointmentSubject
    {
        private readonly List<IAppointmentObserver> _observers = new();

        public void Attach(IAppointmentObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IAppointmentObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Appointment appointment)
        {
            foreach (var observer in _observers)
            {
                observer.Update(appointment);
            }
        }
    }
}
