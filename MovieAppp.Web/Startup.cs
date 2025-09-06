using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MovieAppp.Web
{
    public class Startup
    {
        // Servis ekleme kısmı
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC (Model-View-Controller) servisini ekledik
            services.AddControllersWithViews();
        }

        // Middleware pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
