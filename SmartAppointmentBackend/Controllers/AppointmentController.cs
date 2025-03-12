using Microsoft.AspNetCore.Mvc;
using SmartAppointmentBackend.Models;
using SmartAppointmentBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SmartAppointmentBackend.Strategies;
using SmartAppointmentBackend.Observers;



namespace SmartAppointmentBackend.Controllers
{
    [Authorize]
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IAppointmentSubject _appointmentSubject;

        private readonly IAppointmentObserver _appointmentObserver;

        public AppointmentController(
            IAppointmentRepository repository,
            IAppointmentSubject appointmentSubject,
            IAppointmentObserver appointmentObserver // Inject the observer
        )
        {
            _appointmentRepository = repository;
            _appointmentSubject = appointmentSubject;
            _appointmentObserver = appointmentObserver;

            _appointmentSubject.Attach(_appointmentObserver); // Attach it here
        }


        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return Ok(await _appointmentRepository.GetAppointmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] Appointment appointment)
        {
            IAppointmentStrategy strategy = new PatientAppointmentStrategy(_appointmentRepository);
            bool success = await strategy.BookAppointment(appointment);

            if (!success) return BadRequest("Appointment slot already booked.");
            return Ok("Appointment booked successfully.");
        }


        [HttpPost]
        public async Task<ActionResult> CreateAppointment(Appointment appointment)
        {
            await _appointmentRepository.AddAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }
}
