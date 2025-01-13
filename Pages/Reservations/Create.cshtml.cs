using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAplicatieWEB.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        [BindProperty]
        public List<string> SelectedSeats { get; set; } = new List<string>();

        public SelectList Showtimes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Populează lista de showtimes pentru dropdown
            Showtimes = new SelectList(await _context.Showtime
                .Select(s => new
                {
                    s.Id,
                    Display = $"{s.Movie.Title} - {s.DateTime:G}" // Combina titlul filmului cu ora showtime-ului
                })
                .ToListAsync(), "Id", "Display");

            ViewData["Showtimes"] = Showtimes;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reîncarcă lista de showtimes dacă apar erori
                Showtimes = new SelectList(await _context.Showtime
                    .Select(s => new
                    {
                        s.Id,
                        Display = $"{s.Movie.Title} - {s.DateTime:G}" // Combina titlul filmului cu ora showtime-ului
                    })
                    .ToListAsync(), "Id", "Display");
                ViewData["Showtimes"] = Showtimes;

                return Page();
            }

            // Salvează locurile selectate
            Reservation.Seats = string.Join(",", SelectedSeats);

            // Adaugă rezervarea în baza de date
            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public IActionResult OnGet()
        {
            ViewData["Showtimes"] = new SelectList(_context.Showtime, "Id", "DateTime"); // Ajustează pentru coloana corectă din baza de date
            return Page();
        }

    }
}
