using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaAplicatieWEB.Models
{
    public class Showtime
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
