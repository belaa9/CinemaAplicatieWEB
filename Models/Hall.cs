using System.ComponentModel.DataAnnotations;

namespace CinemaAplicatieWEB.Models
{
    public class Hall
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? Layout { get; set; }
    }
}
