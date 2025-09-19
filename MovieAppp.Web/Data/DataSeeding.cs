using Microsoft.EntityFrameworkCore;
using MovieAppp.Web.Entity;

namespace MovieAppp.Web.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService < MovieContext > ();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() ==0)
            {
                if (context.Movies.Count()==0)
                {
                    context.Movies.AddRange(
                         new Movie
                         {
                             MovieId = 1,
                             Title = "Jiu Jitsu",
                             Description = "Dünya'yı istilaya gelen uzaylılara karşı antik Jiu Jitsu savaşçıları savaşmak zorundadır.",
                             

                             ImageUrl = "1.jpg",
                             GenreId = 1
                         },
        new Movie
        {
            MovieId = 2,
            Title = "Zenci 2",
            Description = "Yeraltı dünyasında geçen intikam ve aksiyon dolu bir devam hikayesi.",
            

            ImageUrl = "2.jpg",
            GenreId = 1
        },
        new Movie
        {
            MovieId = 3,
            Title = "Zenci 2",
            Description = "Bir baba, ailesini korumak için geçmişte yaptığı hatalarla yüzleşmek zorunda kalır.",
            
            ImageUrl = "3.jpg",
            GenreId = 2
        },
        new Movie
        {
            MovieId = 4,
            Title = "Tenet",
            Description = "Zamanı tersine çevirerek geleceği kurtarmaya çalışan gizli bir ajanın hikayesi.",
            
            ImageUrl = "4.jpg",
            GenreId = 3
        },
        new Movie
        {
            MovieId = 5,
            Title = "Tenet",
            Description = "Paralel gerçeklikler ve zaman kırılmalarıyla dolu akıl almaz bir casusluk hikayesi.",
            ImageUrl = "5.jpg",
            GenreId = 3
        },
        new Movie
        {
            MovieId = 6,
            Title = "Zenci 2",
            Description = "Savaşın gölgesinde, dostluk ve ihanet arasında sıkışan bir adamın dramı.",
            

            ImageUrl = "6.jpg",
            GenreId = 4
        }
                        );
                }

                if(context.Genres.Count()==0)
                {
                    context.Genres.AddRange(

                        new Genre { GenreId = 1, Name = "Macera" },
                    new Genre { GenreId = 2, Name = "Dram" },
                    new Genre { GenreId = 3, Name = "Romantik" },
                    new Genre { GenreId = 4, Name = "Savaş" }
                    );
                }
            }

            context.SaveChanges();
        }

    }
}
