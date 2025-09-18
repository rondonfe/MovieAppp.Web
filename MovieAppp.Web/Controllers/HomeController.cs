using Microsoft.AspNetCore.Mvc;
using MovieAppp.Web.Data;
using MovieAppp.Web.Entity;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                PopularMovies = _context.Movies.ToList()
            };

            return View(model);
        
            
            
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
