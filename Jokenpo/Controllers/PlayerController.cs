using Jokenpo.Context;
using Jokenpo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            var players = _context.Players.ToList();

            return players;
        }       
        
        
        [HttpGet("{id:int}", Name = "GetPlayer")]
        public ActionResult<Player> Get(int Id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == Id);

            if(player == null)
            {
                return NotFound("Player not found");
            }

            return player;
        }

        [HttpPost]
        public ActionResult Post(Player player)
        {
            if(player is null) return BadRequest("Invalid player");

            _context.Add(player);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetPlayer", new {id = player.Id}, player);
        }
    }
}