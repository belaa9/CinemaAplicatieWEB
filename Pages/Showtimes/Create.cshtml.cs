using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Linq;

namespace CinemaAplicatieWEB.Pages.Showtimes
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Showtime Showtime { get; set; } = default!;

        public IActionResult OnGet()
        {
            try
            {
                // Populare lista de filme
                var movies = _context.Movie.ToList();
                if (!movies.Any())
                {
                    ViewData["Movies"] = new SelectList(new List<object>(), "Id", "Title");
                }
                else
                {
                    ViewData["Movies"] = new SelectList(movies, "Id", "Title");
                }

                // Populare lista de săli
                var halls = _context.Hall.Select(h => new { h.Id, h.Name }).ToList();
                if (!halls.Any())
                {
                    ViewData["Halls"] = new SelectList(new List<object>(), "Id", "Name");
                }
                else
                {
                    ViewData["Halls"] = new SelectList(halls, "Id", "Name");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Eroare la popularea datelor: {ex.Message}");
                return Page();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Salvare Showtime în baza de date
            _context.Showtime.Add(Showtime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
