using System.Collections.Generic;

namespace CinemaAplicatieWEB.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; } // În minute

        // Genuri disponibile pentru selectare (folosit pentru listare și afisare detaliată)
        public List<GenreOption> AvailableGenres { get; set; } = new();

        // Genuri introduse manual (pentru creare/editare)
        public string Genres { get; set; } = string.Empty; // Genurile separate prin virgulă
    }

    public class GenreOption
    {
        public string Name { get; set; } = string.Empty; // Nume gen
        public bool IsSelected { get; set; } // Este selectat sau nu
    }
}
