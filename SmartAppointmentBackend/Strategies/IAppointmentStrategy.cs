using SmartAppointmentBackend.Models;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Strategies
{
    public interface IAppointmentStrategy
    {
        Task<bool> BookAppointment(Appointment appointment);
    }
}
