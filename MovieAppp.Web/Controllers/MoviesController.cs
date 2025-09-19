using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAppp.Web.Data;
using MovieAppp.Web.Entity;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

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

            var movies = _context.Movies.AsQueryable();

            // Eğer id null değilse, yani kategori seçildiyse, sadece o kategoriye ait filmleri alıyoruz.
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id);
            }

            _context.Genres.Where(g => g.GenreId == id).Select(x => x.Movies).ToList();

            /*
             Select * from Genres g  
            inner join Movies m on g.GenreId=m.GenreId
             where GenreID=id
             */

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower()));
            }

            // ViewModel oluşturuluyor.
            // ViewModel -> View'e hangi verilerin gönderileceğini belirleyen özel model sınıfıdır.
            // Burada sadece Movies listesi ekleniyor ama istersek kategori adı, toplam film sayısı gibi ekstra veriler de koyabiliriz.
            var model = new MovieViewModel()
            {
                Movies = movies.ToList()
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
            return View(_context.Movies.Find(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.AddMovie(m);
                _context.Movies.Add(m);
                _context.SaveChanges();

                TempData["Message"] = $"{m.Title} isimli film eklendi";
                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(_context.Movies.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(m);
                _context.Movies.Update(m);
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "GenreId", "Name");
            return View(m);
        }

        [HttpPost]
        public IActionResult Delete(int MovieId,string Title)
        {
            //MovieRepository.Delete(MovieId);
            var entity = _context.Movies.Find(MovieId);
             _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");
        }
    }
}
