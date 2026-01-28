using System.Collections.ObjectModel;

namespace Jokenpo.Models
{
    public class Move
    {

        public Move()
        {
            Movements = new Collection<Move>();
        }

        public int Id {get; set;}

        public string Name {get; set;}

        public ICollection<Move> Movements{get; set;}
    }
}