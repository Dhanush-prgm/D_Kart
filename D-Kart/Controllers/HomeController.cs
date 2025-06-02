using System.Diagnostics;
using D_Kart.Domain.Interfaces.IProduct;
using D_Kart.Models;
using Microsoft.AspNetCore.Mvc;

namespace D_Kart.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService context) : base(context)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CartCount = await GetCartCountAsync(); // Ensure cart count is set
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewBag.CartCount = await GetCartCountAsync(); // Ensure cart count is set
            return View();
        }
    }

}
