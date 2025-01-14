using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservations { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Reservations = await _context.Reservation
                .Include(r => r.User) // Include utilizatorii
                .Include(r => r.Hall) // Include sălile
                .ToListAsync();
        }
    }
}