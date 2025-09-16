using Microsoft.AspNetCore.Mvc;
using MovieAppp.Web.Data;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularMovies = MovieRepository.Movies
            };

            return View(model);
        
            
            
        }

        public IActionResult About()
        {



            return View();
        }
    }
}
