using Microsoft.AspNetCore.Mvc;
using WebApplication5.DbContexxt;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/venues")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
            return await _context.Venues.Include(v => v.Events).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _context.Venues
                .Include(v => v.Events)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venue == null) return NotFound();
            return venue;
        }

        [HttpPost]
        public async Task<ActionResult<Venue>> CreateVenue(Venue venue)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenue), new { id = venue.Id }, venue);
        }
    }
