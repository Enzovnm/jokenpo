using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Jokenpo.Models
{
    public class Player
    {

        public Player()
        {
            MatchMoves = new Collection<MatchMove>();
        }

        public int Id {get; set;}

        [Required]
        public string Name {get; set;}

        public ICollection<MatchMove> MatchMoves {get; set;}
    }
}