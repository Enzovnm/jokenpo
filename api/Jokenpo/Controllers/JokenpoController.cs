using Jokenpo.Context;
using Jokenpo.Dtos;
using Jokenpo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jokenpo.Controllers
{
    [ApiController]
    [Route("jokenpo")]
    public class JokenpoController : ControllerBase
    {
        private readonly AppDbContext _context;


        public JokenpoController(AppDbContext context){
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JokenpoRequest jokenpoRequest)
        {
            var player1 = await _context.Players.FirstOrDefaultAsync(p => p.Id == jokenpoRequest.Player1Id);
            var player2 = await _context.Players.FirstOrDefaultAsync(p => p.Id == jokenpoRequest.Player2Id);

            var playerOneMovement = await _context.Movements.Include(m => m.Winners).FirstOrDefaultAsync(p => p.Id == jokenpoRequest.Player1MovementId);
            var playerTwoMovement = await _context.Movements.FirstOrDefaultAsync(p => p.Id == jokenpoRequest.Player2MovementId);

            if(player1 == player2) return BadRequest("You can't play against yourself");

            if(player1 == null) return NotFound("Player1 Not Found");

            

            if(player2 == null) return NotFound("Player2 Not Found");

            if(playerOneMovement == null) return NotFound("playerOneMovement not found");

            if(playerTwoMovement == null) return NotFound("playerTwoMovement not found");

            
            var match = new Match();

        
            match.MatchMoves.Add(new MatchMove
            {
                Player = player1,
                Move = playerOneMovement
            });

            match.MatchMoves.Add(new MatchMove
            {
                Player = player2,
                Move = playerTwoMovement
            });

            string resultMessage;


            if(playerOneMovement.Id == playerTwoMovement.Id)
            {
                resultMessage = "Empate!";
            }
            else if (playerOneMovement.Winners.Any(p => p.Id == playerTwoMovement.Id))
            {
                resultMessage = "Player 1 Wins";
            }
            else
            {
                resultMessage = "Player 2 Wins";
            }

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
        


            return Ok(new { MatchId = match.Id, Message = resultMessage });

        }
    }
}