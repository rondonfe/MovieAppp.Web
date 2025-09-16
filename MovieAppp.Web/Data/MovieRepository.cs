using MovieAppp.Web.Models;

namespace MovieAppp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                  new Movie
                {
                    MovieId=1,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="1.jpg",
                    GenreId=1
                },
                 new Movie
                {
                     MovieId=2,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="2.jpg",
                    GenreId=1
                },
                  new Movie
                {
                      MovieId=3,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="3.jpg",
                    GenreId=3
                },
                   new Movie
                {
                       MovieId=4,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="1.jpg",
                    GenreId=4
                },
                     new Movie
                {
                      MovieId=5,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="3.jpg",
                    GenreId=1
                },
                       new Movie
                {
                      MovieId=6,
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = new List<string> { "oyuncu1", "oyuncu2" },
                    ImageUrl="3.jpg",
                    GenreId=3
                }

            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public static Movie GetMovieById (int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
    }
}
