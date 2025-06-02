using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.Domain.Interfaces.IFavorite;
using D_Kart.Domain.Models;

namespace D_Kart.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task Add(int id)
        {
            var fav = new Favorite { ProductId = id };
            await _favoriteRepository.Add(fav);
        }

        public async Task<bool> Exists(int id)
        {
            return await  _favoriteRepository.Exists(id);
        }

        public async Task<Favorite> Find(int id)
        {
            return await _favoriteRepository.Find(id);
        }

        public async Task<List<Favorite>> List()
        {
            return await _favoriteRepository.List();
        }

        public async Task Remove(Favorite favorite)
        {
            await _favoriteRepository.Remove(favorite);
        }

        public async Task<int> GetCartCountAsync()
        {
            return await _favoriteRepository.GetCartCountAsync();

        }
    }
}
