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

      

        public string? ImageUrl { get; set; }

        // GenreId zorunlu
        public Genre Genre { get; set; } //navigation property
        public int? GenreId { get; set; }
    }
}
