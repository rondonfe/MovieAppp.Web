namespace MovieAppp.Web.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Directors { get; set; }
        public List<string> Players { get; set; } // Burayı güncelledik
        public string ImageUrl { get; set; } // Eğer yoksa ekleyebilirsin

        public int GenreId { get; set; }
    }
}