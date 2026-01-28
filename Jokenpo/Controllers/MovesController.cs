using Jokenpo.Context;
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
    }
}