using Jokenpo.Context;
using Jokenpo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersControllers : ControllerBase
    {

        private readonly AppDbContext _context;

        public PlayersControllers(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            var players = await _context.Players.ToListAsync();

            return players;
        }       
        
        
        [HttpGet("{id:int}", Name = "GetPlayer")]
        public async Task<ActionResult<Player>> Get(int Id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == Id);

            if(player == null)
            {
                return NotFound("Player not found");
            }

            return player;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Player player)
        {
            if(player is null) return BadRequest("Invalid player");

            _context.Add(player);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetPlayer", new {id = player.Id}, player);
        }
    }
}