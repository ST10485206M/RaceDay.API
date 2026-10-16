using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventEnrollmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventEnrollment>>> GetEnrollments()
        {
            return await _context.EventEnrollments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventEnrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.EventEnrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            return enrollment;
        }

        [HttpPost]
        public async Task<ActionResult<EventEnrollment>> CreateEnrollment(
            EventEnrollment enrollment)
        {
            enrollment.EnrollmentDate = DateTime.Today;

            _context.EventEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEnrollment),
                new { id = enrollment.EnrollmentID },
                enrollment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.EventEnrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            _context.EventEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}