using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaAplicatieWEB.Data
{
    public class CinemaIdentityContext : IdentityDbContext
    {
        public CinemaIdentityContext(DbContextOptions<CinemaIdentityContext> options)
            : base(options)
        {
        }
    }
}
