using System.ComponentModel.DataAnnotations;
using Jokenpo.Models;

namespace Jokenpo.Dtos
{
    public class JokenpoRequest
    {
        [Required]
        public int Player1Id {get; set;}

        [Required]
        public int Player2Id {get; set;}

        [Required]
        public int Player1MovementId {get; set;}

        [Required]
        public int Player2MovementId {get; set;}
    }
}