using System.Threading.Tasks;
using D_Kart.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace D_Kart.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Submit()
        {
            var reviews = await _reviewService.GetRecentReviewsAsync();
            return View(reviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(string feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback) || feedback.Length > 500)
            {
                ModelState.AddModelError("Feedback", "Feedback is required and should be less than 500 characters.");
                var reviews = await _reviewService.GetRecentReviewsAsync();
                return View(reviews);
            }

            await _reviewService.AddReviewAsync(feedback);
            TempData["Success"] = "Thank you for your feedback!";
            return RedirectToAction("Submit");
        }
    }
}
