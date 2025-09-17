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
            MovieId = 1,
            Title = "Jiu Jitsu",
            Description = "Dünya'yı istilaya gelen uzaylılara karşı antik Jiu Jitsu savaşçıları savaşmak zorundadır.",
            Directors = "Dimitri Logothetis",
            Players = new List<string> { "Nicolas Cage", "Alain Moussi" },
            ImageUrl = "1.jpg",
            GenreId = 1
        },
        new Movie
        {
            MovieId = 2,
            Title = "Zenci 2",
            Description = "Yeraltı dünyasında geçen intikam ve aksiyon dolu bir devam hikayesi.",
            Directors = "Dimitri Logothetis",
            Players = new List<string> { "Nicolas Cage", "Alain Moussi" },
            ImageUrl = "2.jpg",
            GenreId = 1
        },
        new Movie
        {
            MovieId = 3,
            Title = "Zenci 2",
            Description = "Bir baba, ailesini korumak için geçmişte yaptığı hatalarla yüzleşmek zorunda kalır.",
            Directors = "Dimitri Logothetis",
            Players = new List<string> { "oyuncu1", "oyuncu2" },
            ImageUrl = "3.jpg",
            GenreId = 2
        },
        new Movie
        {
            MovieId = 4,
            Title = "Tenet",
            Description = "Zamanı tersine çevirerek geleceği kurtarmaya çalışan gizli bir ajanın hikayesi.",
            Directors = "Christopher Nolan",
            Players = new List<string> { "John David Washington", "Robert Pattinson" },
            ImageUrl = "4.jpg",
            GenreId = 3
        },
        new Movie
        {
            MovieId = 5,
            Title = "Tenet",
            Description = "Paralel gerçeklikler ve zaman kırılmalarıyla dolu akıl almaz bir casusluk hikayesi.",
            Directors = "Christopher Nolan",
            Players = new List<string> { "John David Washington", "Elizabeth Debicki" },
            ImageUrl = "5.jpg",
            GenreId = 3
        },
        new Movie
        {
            MovieId = 6,
            Title = "Zenci 2",
            Description = "Savaşın gölgesinde, dostluk ve ihanet arasında sıkışan bir adamın dramı.",
            Directors = "Dimitri Logothetis",
            Players = new List<string> { "oyuncu1", "oyuncu2" },
            ImageUrl = "6.jpg",
            GenreId = 4
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

                    movie.MovieId = _movies.Count() + 1;
                _movies.Add(movie);
            }

            public static Movie GetMovieById (int id)
            {
                return _movies.FirstOrDefault(m => m.MovieId == id);
            }

            public static void Edit(Movie m)
            {
                foreach (var movie in _movies)
                {
                    if(movie.MovieId==m.MovieId)
                    {
                        movie.Title = m.Title;
                        movie.Description = m.Description;
                        movie.Directors = m.Directors;
                        movie.ImageUrl = m.ImageUrl;
                        movie.GenreId = m.GenreId;
                        break;
                    }
                }
            }

          public static void Delete(int MovieId)
        {
            var movie = GetMovieById(MovieId);

            if (movie != null)
            {
                _movies.Remove(movie);
            }
            
        }
        }
    }
