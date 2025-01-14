using CinemaAplicatieWEB.Models;

public class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HallId { get; set; }
    public string Seats { get; set; } = string.Empty; // E.g., "A1,A2,A3"
    public DateTime ReservationDate { get; set; } // Include și data, și ora

    // Relații de navigare
    public User User { get; set; } = null!;
    public Hall Hall { get; set; } = null!;
}
