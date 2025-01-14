using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaAplicatieWEB.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public List<Movie> Movies { get; set; } = new();

        public void OnGet()
        {
            Movies = _context.Movie
                .AsEnumerable() // Mutăm evaluarea pe partea clientului
                .Select(m => new Movie
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Duration = m.Duration,
                    Genres = string.Join(", ", m.AvailableGenres.Select(g => g.Name)) // Afișare genuri ca text
                })
                .ToList();
        }
    }
}
