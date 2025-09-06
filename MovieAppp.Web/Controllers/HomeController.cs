using Microsoft.AspNetCore.Mvc;
using MovieAppp.Web.Models;

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

            var m = new Movie();

            m.Title = filmBasligi;
            m.Description = filmAciklama;
            m.Directors = filmYonetmen;
            m.Players = string.Join(", ", oyuncular);

            return View(m);
            /*
             Ne oluyor burada?

filmBasligi, filmAciklama, filmYonetmen, oyuncular gibi ham veriler oluşturuyorsun.

Movie modelinden bir m nesnesi üretiyorsun.

m nesnesinin property’lerini (Title, Description, Directors, Players) az önceki ham verilerle dolduruyorsun.

m nesnesini View’e gönderiyorsun → return View(m);
             */
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
