using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using D_Kart.Domain.Interfaces;
using D_Kart.Domain.Models;

namespace D_Kart.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task AddReviewAsync(string feedback)
        {
            var review = new Review
            {
                Feedback = feedback,
                DateSubmitted = DateTime.Now
            };
            await _reviewRepository.AddAsync(review);
        }

        public async Task<List<Review>> GetRecentReviewsAsync(int count = 5)
        {
            return await _reviewRepository.GetRecentAsync(count);
        }
    }
}