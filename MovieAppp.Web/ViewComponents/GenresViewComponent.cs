using Microsoft.AspNetCore.Mvc;
using MovieAppp.Web.Data;
using MovieAppp.Web.Models;

namespace MovieAppp.Web.ViewComponents
{
    // ViewComponent: Tekrar kullanılabilir küçük UI parçaları oluşturur.
    // Mesela kategori menüsü, sepet özeti, kullanıcı profili gibi.

    public class GenresViewComponent : ViewComponent
    {
        // Invoke() → Bu ViewComponent çağrıldığında çalışır.
        public IViewComponentResult Invoke()
        {
            // RouteData.Values["id"]: URL’den gelen id parametresini alır.
            // Örn: "/movies/list/2" çağrılırsa, id = 2 olur.
            ViewBag.SelectedGenre = RouteData.Values["id"];

            // GenreRepository.Genres: Statik olarak tanımlı kategori listesi.
            // Bu listeyi View’e gönderiyoruz.
            return View(GenreRepository.Genres);
        }
    }
}
