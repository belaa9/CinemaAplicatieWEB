using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DeleteModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Movie = await _context.Movie.FindAsync(id);

            if (Movie == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movie.FindAsync(id);

            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
