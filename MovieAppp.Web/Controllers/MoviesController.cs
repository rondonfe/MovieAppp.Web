using Microsoft.AspNetCore.Mvc;

namespace MovieAppp.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
