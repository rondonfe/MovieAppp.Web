using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAppp.Web.Data;
using MovieAppp.Web.Entity;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.ViewComponents
{
   
    // ViewComponent: Tekrar kullanılabilir küçük UI parçaları oluşturur.
    // Mesela kategori menüsü, sepet özeti, kullanıcı profili gibi.

    public class GenresViewComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }
        // Invoke() → Bu ViewComponent çağrıldığında çalışır.
        public IViewComponentResult Invoke()
        {
            // RouteData.Values["id"]: URL’den gelen id parametresini alır.
            // Örn: "/movies/list/2" çağrılırsa, id = 2 olur.
            ViewBag.SelectedGenre = RouteData.Values["id"];

            // GenreRepository.Genres: Statik olarak tanımlı kategori listesi.
            // Bu listeyi View’e gönderiyoruz.
            return View(_context.Genres.ToList());
        }
    }
}
