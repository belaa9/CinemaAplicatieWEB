using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DetailsModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Movie = await _context.Movie.FindAsync(id);

            if (Movie == null) return NotFound();

            return Page();
        }
    }
}
