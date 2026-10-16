using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganisersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Organisers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organiser>>> GetOrganisers()
        {
            return await _context.Organisers.ToListAsync();
        }

        // GET: api/Organisers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Organiser>> GetOrganiser(int id)
        {
            var organiser = await _context.Organisers.FindAsync(id);

            if (organiser == null)
                return NotFound();

            return organiser;
        }

        // POST: api/Organisers
        [HttpPost]
        public async Task<ActionResult<Organiser>> CreateOrganiser(Organiser organiser)
        {
            _context.Organisers.Add(organiser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrganiser),
                new { id = organiser.OrganiserID },
                organiser);
        }

        // PUT: api/Organisers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganiser(
            int id, Organiser organiser)
        {
            if (id != organiser.OrganiserID)
                return BadRequest();

            _context.Entry(organiser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Organisers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganiser(int id)
        {
            var organiser = await _context.Organisers.FindAsync(id);

            if (organiser == null)
                return NotFound();

            _context.Organisers.Remove(organiser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}