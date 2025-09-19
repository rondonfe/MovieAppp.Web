using Microsoft.EntityFrameworkCore;

namespace MovieAppp.Web.Entity
{
    // MovieContext : DbContext => Veritabanı ile uygulama arasında köprü kuran sınıf
    public class MovieContext : DbContext
    {
        // Startup.cs üzerinden gelen ayarları (DbContextOptions)
        // base sınıfa (DbContext) gönderiyoruz
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Movies tablosuna karşılık gelen DbSet
        public DbSet<Movie> Movies { get; set; } = null!;

        // Genres tablosuna karşılık gelen DbSet
        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Director> Directors { get; set; }
    }
}
