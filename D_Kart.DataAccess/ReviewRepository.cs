using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D_Kart.Domain.Interfaces;
using D_Kart.Domain.Models;
using D_Kart.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetRecentAsync(int count = 5)
        {
            return await _context.Reviews
                .OrderByDescending(r => r.DateSubmitted)
                .Take(count)
                .ToListAsync();
        }
    }
}