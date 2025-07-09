using System.Collections.Generic;
using System.Threading.Tasks;
using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces
{
    public interface IReviewService : IBaseService
    {
        Task AddReviewAsync(string feedback);
        Task<List<Review>> GetRecentReviewsAsync(int count = 5);
    }
}