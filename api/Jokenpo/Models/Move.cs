using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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


        [JsonIgnore]
        public ICollection<Move> Winners{get; set;}
    }
}