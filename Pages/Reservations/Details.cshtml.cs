using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaAplicatieWEB.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DetailsModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Reservation = await _context.Reservation
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Reservation == null) return NotFound();

            return Page();
        }
    }
}
