using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieAppp.Web.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [DisplayName("Baslık")]
        [Required(ErrorMessage ="film baslığı eklemelisiniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "film baslığı eklemelisiniz")]
        public string Description { get; set; }
        public string Directors { get; set; }
        public List<string> Players { get; set; } = new List<string>(); // Varsayılan olarak boş liste
        [Required(ErrorMessage ="Filmin görselini eklemelisiniz")]
        public string ImageUrl { get; set; } // Eğer yoksa ekleyebilirsin

        public int GenreId { get; set; }
    }
}