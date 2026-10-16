using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            return await _context.Participants
                .Select(p => new Participant
                {
                    ParticipantID = p.ParticipantID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var p = await _context.Participants.FindAsync(id);

            if (p == null)
                return NotFound();

            return new Participant
            {
                ParticipantID = p.ParticipantID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email
            };
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> CreateParticipant(
            Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetParticipant),
                new { id = participant.ParticipantID },
                new
                {
                    participant.ParticipantID,
                    participant.FirstName,
                    participant.LastName,
                    participant.Email
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipant(
            int id, Participant participant)
        {
            if (id != participant.ParticipantID)
                return BadRequest();

            var existing = await _context.Participants.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.FirstName = participant.FirstName;
            existing.LastName = participant.LastName;
            existing.Email = participant.Email;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);

            if (participant == null)
                return NotFound();

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}