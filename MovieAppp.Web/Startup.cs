using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAppp.Web.Data;
using MovieAppp.Web.Entity;

namespace MovieAppp.Web
{
    public class Startup
    {
        // IConfiguration arayüzü sayesinde appsettings.json'daki
        // ConnectionString gibi ayarları okuyabiliyoruz
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Uygulamanın ihtiyaç duyduğu servisleri buraya ekliyoruz
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC (Model-View-Controller) servisini ekliyoruz
            services.AddControllersWithViews();

            // Veritabanı bağlantısını ekleme
            // Burada MovieContext sınıfını DbContext olarak tanımlıyoruz
            // appsettings.json içindeki "DefaultConnection" kısmından
            // SQLite bağlantı cümlesini çekiyor
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        }


        // Middleware pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }

            app.UseStaticFiles();//wwwroot

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                //endpoints.MapControllerRoute(
                //    name: "home",
                //    pattern: "",
                //    defaults: new { controller = "Home", action = "Index" }
                //    );

                //endpoints.MapControllerRoute(
                //    name: "aboutpage",
                //    pattern: "about",
                //    defaults: new { controller = "Home", action = "about" }
                //    );

                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern:"movies/list",
                //    defaults: new { controller = "Movies",action = "List"}
                //    );

                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern: "movies/details",
                //    defaults: new { controller = "Movies", action = "Details" }
                //    );
            });
        }
    }
}
