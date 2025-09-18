using System.ComponentModel.DataAnnotations;

namespace MovieAppp.Web.Entity
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        // Null olabilir
        public string? Description { get; set; }

        public string? Directors { get; set; }

        // List null olamaz, varsayılan boş liste
        public List<string> Players { get; set; } = new List<string>();

        public string? ImageUrl { get; set; }

        // GenreId zorunlu
        public int GenreId { get; set; }
    }
}
