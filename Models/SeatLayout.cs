namespace CinemaAplicatieWEB.Models
{
    public class SeatGrid
    {
        public List<Row> Rows { get; set; } = new();
    }

    public class Row
    {
        public string RowName { get; set; } = string.Empty; // Schimbat din Row în RowName
        public List<string> Seats { get; set; } = new();
    }

}
