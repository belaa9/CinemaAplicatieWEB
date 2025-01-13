using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public EditModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Movie = await _context.Movie.FindAsync(id);

            if (Movie == null)
                return NotFound();

            // Transformăm AvailableGenres în string-ul Genres pentru editare
            Movie.Genres = string.Join(", ", Movie.AvailableGenres.Select(g => g.Name));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var movieToUpdate = await _context.Movie.FindAsync(Movie.Id);

            if (movieToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync(movieToUpdate, "Movie", m => m.Title, m => m.Description, m => m.Duration))
            {
                // Transformăm string-ul Genres în AvailableGenres
                movieToUpdate.AvailableGenres = Movie.Genres.Split(',')
                    .Select(g => new GenreOption { Name = g.Trim(), IsSelected = true })
                    .ToList();

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
