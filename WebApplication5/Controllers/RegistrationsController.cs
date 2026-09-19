using Microsoft.AspNetCore.Mvc;
using WebApplication5.DbContexxt;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/registrations")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            return await _context.Registrations
                .Include(r => r.Event)
                .Include(r => r.Attendee)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> CreateRegistration(Registration registration)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Verify required related entities exist
            var eventExists = await _context.Events.AnyAsync(e => e.Id == registration.EventId);
            var attendeeExists = await _context.Attendees.AnyAsync(a => a.Id == registration.AttendeeId);

            if (!eventExists || !attendeeExists)
            {
                return BadRequest("The specified EventId or AttendeeId does not exist.");
            }

            // Check for duplicate registration
            var alreadyRegistered = await _context.Registrations
                .AnyAsync(r => r.EventId == registration.EventId && r.AttendeeId == registration.AttendeeId);

            if (alreadyRegistered)
            {
                return BadRequest("This attendee is already registered for this event.");
            }

            registration.RegistrationDate = DateTime.Now;

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistrations), new { id = registration.Id }, registration);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRegistrationStatus(int id, [FromBody] string status)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null) return NotFound();

            if (string.IsNullOrEmpty(status) || status.Length > 30)
            {
                return BadRequest("Status is required and must be less than 30 characters.");
            }

            registration.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
