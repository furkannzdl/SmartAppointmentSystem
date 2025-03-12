using SmartAppointmentBackend.Models;
using SmartAppointmentBackend.Repositories;
using System;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Observers
{
    public class EmailNotificationObserver : IAppointmentObserver
    {
        private readonly IUserRepository _userRepository;

        public EmailNotificationObserver(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async void Update(Appointment appointment)
        {
            var user = await _userRepository.GetUserByIdAsync(appointment.UserId);
            if (user != null)
            {
                Console.WriteLine($"📧 Sending email to {user.Username} ({user.Email}) for appointment on {appointment.AppointmentDate}");
            }
            else
            {
                Console.WriteLine("⚠️ Failed to fetch user email for notification.");
            }
        }
    }
}
