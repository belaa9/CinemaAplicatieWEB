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
            Movies = _context.Movie.ToList();
        }
    }
}
