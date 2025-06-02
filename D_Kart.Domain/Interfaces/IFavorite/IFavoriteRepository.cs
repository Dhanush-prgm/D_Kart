using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces.IFavorite
{
    public interface IFavoriteRepository : IBaseRepository
    {
        Task Add(Favorite favorite);
        Task<List<Favorite>> List();
        Task Remove(Favorite favorite);
        Task<bool> Exists(int id);
        Task<Favorite> Find(int id);    
    }
}
