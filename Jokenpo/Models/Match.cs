using System.Collections.ObjectModel;

namespace Jokenpo.Models
{
    public class Match
    {

        public Match ()
        {
            MatchMoves = new Collection<MatchMove>();
        }

        public int Id {get; set;}

        public ICollection<MatchMove> MatchMoves { get; set; }


    }
}