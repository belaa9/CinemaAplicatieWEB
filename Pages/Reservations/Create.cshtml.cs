using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public Reservation Reservation { get; set; } = new();

        [BindProperty]
        public List<string> SelectedSeats { get; set; } = new();

        public IActionResult OnGet()
        {
            ViewData["Users"] = new SelectList(_context.User, "Id", "Name");
            ViewData["Halls"] = new SelectList(_context.Hall, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Users"] = new SelectList(_context.User, "Id", "Name");
                ViewData["Halls"] = new SelectList(_context.Hall, "Id", "Name");
                return Page();
            }

            Reservation.Seats = string.Join(",", SelectedSeats);
            Reservation.ReservationDate = Reservation.ReservationDate;

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
