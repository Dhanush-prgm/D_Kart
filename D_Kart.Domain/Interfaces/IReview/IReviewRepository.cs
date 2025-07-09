using System.Collections.Generic;
using System.Threading.Tasks;
using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces
{
    public interface IReviewRepository : IBaseRepository
    {
        Task AddAsync(Review review);
        Task<List<Review>> GetRecentAsync(int count = 5);
    }
}