using System.Collections.ObjectModel;

namespace Jokenpo.Models
{
    public class Player
    {

        public Player()
        {
            Matches = new Collection<Match>();
        }

        public int Id {get; set;}
        public string Name {get; set;}

        public ICollection<Match> Matches {get; set;}
    }
}