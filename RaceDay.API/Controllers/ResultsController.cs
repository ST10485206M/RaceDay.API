using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> CreateResult(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetResult),
                new { id = result.ResultsID },
                result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResult(int id, Result result)
        {
            if (id != result.ResultsID)
                return BadRequest();

            var existing = await _context.Results.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.ParticipantID = result.ParticipantID;
            existing.EventID = result.EventID;
            existing.Position = result.Position;
            existing.FinishTime = result.FinishTime;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _context.Results.FindAsync(id);

            if (result == null)
                return NotFound();

            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}