using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.DataAccess.Database;
using D_Kart.Domain.Interfaces.IFavorite;
using D_Kart.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.DataAccess
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _appDbContext;
        public FavoriteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(Favorite favorite)
        {
            await _appDbContext.Favorites.AddAsync(favorite);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _appDbContext.Favorites.AnyAsync(f => f.ProductId == id);

        }

        public async Task<Favorite> Find(int id)
        {
             return await _appDbContext.Favorites.FindAsync(id);

        }

        public async Task<List<Favorite>> List()
        {
            return await _appDbContext.Favorites.Include(f => f.Product).ToListAsync();
        }

        public async Task Remove(Favorite favorite)
        {
            _appDbContext.Favorites.Remove(favorite);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> GetCartCountAsync()
        {
            return await _appDbContext.Products.CountAsync(p => p.IsAddedToCart);

        }

    }
}
