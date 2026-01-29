using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jokenpo.Models
{
    [Table("Movements")]
    public class Move
    {

        public Move()
        {
            Winners = new Collection<Move>();
        }

        public int Id {get; set;}

        [Required]
        public string Name {get; set;}


        [Required]
        public ICollection<Move> Winners{get; set;}
    }
}