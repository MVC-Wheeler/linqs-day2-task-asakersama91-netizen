using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DbContexxt;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events
                .Include(e => e.Venue)
                .Include(e => e.Organizer)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventItem = await _context.Events
                .Include(e => e.Venue)
                .Include(e => e.Organizer)
                .Include(e => e.Registrations)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventItem == null) return NotFound();
            return eventItem;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent(Event eventItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Events.Add(eventItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.Id }, eventItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event eventItem)
        {
            if (id != eventItem.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Entry(eventItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Events.AnyAsync(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateEvent(int id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Event> patchDoc)
        {
            if (patchDoc == null) return BadRequest();

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return NotFound();

            patchDoc.ApplyTo(eventItem, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return NotFound();

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
