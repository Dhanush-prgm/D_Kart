using D_Kart.Domain.Interfaces.IFavorite;
using D_Kart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.Controllers
{
    public class FavoritesController : BaseController
    {
        public FavoritesController(IFavoriteService favoriteService) : base(favoriteService) { }

        // POST: /Favorites/Add/5
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var exists = await ((IFavoriteService)_baseService).Exists(id);
            if (!exists)
            {
                await ((IFavoriteService)_baseService).Add(id);
            }
            return RedirectToAction("Collection", "Products");
        }

        public async Task<IActionResult> List()
        {
            ViewBag.CartCount = await GetCartCountAsync();
            var favs = await ((IFavoriteService)_baseService).List();
            return View(favs);
        }

        // POST: /Favorites/Remove/5
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var fav = await ((IFavoriteService)_baseService).Find(id);
            if (fav != null)
            {
                await ((IFavoriteService)_baseService).Remove(fav);
            }
            return RedirectToAction("List");
        }
    }
}