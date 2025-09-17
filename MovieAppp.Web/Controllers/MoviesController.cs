using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAppp.Web.Data;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Controllers
{
    public class MoviesController : Controller
    {
        // Anasayfa gibi çalışacak aksiyon.
        // Burada henüz film listesi gösterilmiyor, sadece boş bir View dönüyor.
        public IActionResult Index()
        {
            return View();
        }

        // Film listesini getiren aksiyon.
        // "id" parametresi gelirse (kategori/genre id), o kategoriye göre filtreleme yapılıyor.
        public IActionResult List(int? id,string q)
        {
            // Repository'den tüm filmleri alıyoruz.
            //{controller}/{action}/{id?}

            //var controller = RouteData.Values["controller"];
            //var action= RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];

            //var kelime = HttpContext.Request.Query["q"].ToString();

            var movies = MovieRepository.Movies;

            // Eğer id null değilse, yani kategori seçildiyse, sadece o kategoriye ait filmleri alıyoruz.
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }


            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            // ViewModel oluşturuluyor.
            // ViewModel -> View'e hangi verilerin gönderileceğini belirleyen özel model sınıfıdır.
            // Burada sadece Movies listesi ekleniyor ama istersek kategori adı, toplam film sayısı gibi ekstra veriler de koyabiliriz.
            var model = new MovieViewModel()
            {
                Movies = movies
            };

            // "Movies" adındaki View dosyasına (Movies.cshtml) model gönderiliyor.
            // Böylece View tarafında @model MovieViewModel diyerek verilere erişebiliriz.
            return View("Movies", model);
        }

        // Belirli bir filmin detaylarını getiren aksiyon.
        // id parametresi ile film seçiliyor.
        public IActionResult Details(int id)
        {
            // Repository'den id'ye göre film bulunuyor.
            // Bulunan tekil film nesnesi direkt View'e gönderiliyor.
            return View(MovieRepository.GetMovieById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.AddMovie(m);

                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(MovieRepository.GetMovieById(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(m);
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(m);
        }

        [HttpPost]
        public IActionResult Delete(int MovieId,string Title)
        {
            MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");
        }
    }
}
