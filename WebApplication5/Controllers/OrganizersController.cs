using Microsoft.AspNetCore.Mvc;
using WebApplication5.DbContexxt;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/organizers")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            return await _context.Organizers.Include(o => o.Events).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _context.Organizers
                .Include(o => o.Events)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organizer == null) return NotFound();
            return organizer;
        }

        [HttpPost]
        public async Task<ActionResult<Organizer>> CreateOrganizer(Organizer organizer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganizer), new { id = organizer.Id }, organizer);
        }
    }
}
