using D_Kart.Domain.Interfaces.IProduct;
using D_Kart.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IProductService context) : base(context) 
        {
        }

        public async Task<IActionResult> Collection()
        {
            ViewBag.CartCount = await GetCartCountAsync();
            var products = await ((IProductService)_baseService).Collection();
            return View(products);
        }

        public async Task<IActionResult> CartItems()
        {
            ViewBag.CartCount = await GetCartCountAsync();
            var products = await ((IProductService)_baseService).CartItems();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.CartCount = await GetCartCountAsync();
            var product = await ((IProductService)_baseService).Details(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int id)
        {
            await ((IProductService)_baseService).AddToCart(id);

            return RedirectToAction("CartItems");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {

            await ((IProductService)_baseService).RemoveFromCart(id);

            return RedirectToAction("CartItems");
        }
    }
}
