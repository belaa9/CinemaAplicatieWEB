using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Data
{
    public class CinemaAplicatieWEBContext : IdentityDbContext
    {
        public CinemaAplicatieWEBContext(DbContextOptions<CinemaAplicatieWEBContext> options)
            : base(options)
        {
        }

        public DbSet<Hall> Hall { get; set; } = default!;
        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Reservation> Reservation { get; set; } = default!;
        public DbSet<Showtime> Showtime { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User) // Legătura cu User
                .WithMany() // Un User poate avea mai multe rezervări
                .HasForeignKey(r => r.UserId); // Cheia străină este UserId
        }

    }
}
