using Microsoft.AspNetCore.Mvc;

namespace MovieAppp.Web.Controllers
{
    public class HomeController : Controller
    {
            public IActionResult Index()
            {
                string filmBasligi = "film başlığı";
                string filmAciklama = "filmin açıklaması";
                string filmYonetmen = "filmin yönetmwni";
                string[] oyuncular = { "oyuncu1", "oyuncu2" };

                ViewBag.FilmBasligi = filmBasligi;
                ViewBag.FilmAciklama = filmAciklama;
                ViewBag.FilmYonetmeni = filmYonetmen;
                ViewBag.Oyuncular = oyuncular;


                return View();
            }

        public IActionResult About()
        {
            return View();
        }
    }
}
