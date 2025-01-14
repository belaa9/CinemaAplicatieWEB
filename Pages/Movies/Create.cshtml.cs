using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Verificarea modelului
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Salvarea genurilor introduse manual
            if (!string.IsNullOrWhiteSpace(Movie.Genres))
            {
                Movie.AvailableGenres = Movie.Genres
                    .Split(',')
                    .Select(g => new GenreOption { Name = g.Trim(), IsSelected = true })
                    .ToList();
            }

            // Adăugarea filmului în baza de date
            _context.Movie.Add(Movie);

            // Salvarea modificărilor
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
