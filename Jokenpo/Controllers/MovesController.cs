using Jokenpo.Context;
using Jokenpo.Dtos;
using Jokenpo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("moves")]
    public class MovesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public MovesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Move>> Get()
        {
            var moves = await _context.Movements.ToListAsync();

            return moves;
        }       
        
        
        [HttpGet("{id:int}", Name = "GetMoves")]
        public async Task<ActionResult<Move>> Get(int id)
        {
            var move = await _context.Movements.Include(p => p.Winners).FirstOrDefaultAsync(p => p.Id == id);

            if(move == null)
            {
                return NotFound("Move not found");
            }

            return move;
        }

        [HttpPost]
        public async Task<ActionResult<Move>> Post(Move move)
        {
            _context.Movements.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = move.Id }, move);
        }

        [HttpPost("{moveId:int}/winners")]
        public async Task<ActionResult<Move>> AddWinners(int moveId, [FromBody] AddWinnerRequest AddwinnerDto)
        {
            var move = await _context.Movements
                .Include(m => m.Winners)
                .FirstOrDefaultAsync(m => m.Id == moveId);

            if (move == null)
                return NotFound("Move not found");

            if (AddwinnerDto.WinnerIds.Contains(moveId))
            {
                return BadRequest("You cannot win your movement!");
            }


            var winners = await _context.Movements
                .Where(m => AddwinnerDto.WinnerIds.Contains(m.Id))
                .ToListAsync();

            if (!winners.Any())
                return BadRequest("No valid winners provided");

            foreach (var winner in winners)
            {
                if (!move.Winners.Contains(winner))
                    move.Winners.Add(winner);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}