using System.Collections.ObjectModel;

namespace Jokenpo.Models
{
    public class Match
    {

        public Match ()
        {
            Players = new Collection<Player>();
        }

        public int Id {get; set;}

        public ICollection<Player> Players {get; set;}


    }
}