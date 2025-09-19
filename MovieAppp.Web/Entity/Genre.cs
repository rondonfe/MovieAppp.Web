using System.ComponentModel.DataAnnotations;

namespace MovieAppp.Web.Entity
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }

        // Name null olamaz, varsayılan boş string atadık
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; }
    }
}
