using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hall Hall { get; set; } = new Hall();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Setează un layout implicit dacă utilizatorul nu introduce nimic
            if (string.IsNullOrWhiteSpace(Hall.Layout))
            {
                Hall.Layout = @"{
            ""Rows"": [
                { ""RowName"": ""A"", ""Seats"": [""A1"", ""A2"", ""A3"", ""A4"", ""A5"", ""A6"", ""A7"", ""A8"", ""A9"", ""A10"", ""A11""] },
                { ""RowName"": ""B"", ""Seats"": [""B1"", ""B2"", ""B3"", ""B4"", ""B5"", ""B6"", ""B7"", ""B8"", ""B9"", ""B10"", ""B11""] },
                { ""RowName"": ""C"", ""Seats"": [""C1"", ""C2"", ""C3"", ""C4"", ""C5"", ""C6"", ""C7"", ""C8"", ""C9"", ""C10"", ""C11""] }
            ]
        }";
            }

            _context.Hall.Add(Hall);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
