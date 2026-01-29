using System.ComponentModel.DataAnnotations;

namespace Jokenpo.Dtos
{
    public class AddWinnerRequest
    {
        [Required]
        public List<int> WinnerIds { get; set; } = new();

    }
}