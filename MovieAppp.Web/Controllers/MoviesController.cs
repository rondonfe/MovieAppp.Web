using Microsoft.AspNetCore.Mvc;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie
                {
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = string.Join(",", new string[] { "oyuncu1", "oyuncu2" }),
                    ImageUrl="1.jpg"
                },
                 new Movie
                {
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = string.Join(",", new string[] { "oyuncu1", "oyuncu2" }),
                    ImageUrl="2.jpg"
                },
                  new Movie
                {
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = string.Join(",", new string[] { "oyuncu1", "oyuncu2" }),
                    ImageUrl="3.jpg"
                },
                   new Movie
                {
                    Title = "film baslıgı",
                    Description = "film açıklaması",
                    Directors = "film yönetmeni",
                    Players = string.Join(",", new string[] { "oyuncu1", "oyuncu2" }),
                    ImageUrl="1.jpg"
                },
            };

            return View("Movies",filmListesi);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
