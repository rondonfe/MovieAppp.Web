using MovieAppp.Web.Entity;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
                {
                    new Genre {GenreId=1, Name = "Macera" },
                    new Genre { GenreId=2, Name = "Dram" },
                    new Genre {GenreId=3,  Name = "Romantik" },
                    new Genre {GenreId=4    ,  Name = "Savaş" }
                };
        }

        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        public static void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.GenreId == id);
        }
    }
}
