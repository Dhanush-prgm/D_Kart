using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.DataAccess.Database;
using D_Kart.Domain.Interfaces.IProduct;
using D_Kart.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddToCart(Product product)
        {
            product.IsAddedToCart = true;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> CartItems()
        {
            return await _appDbContext.Products.Where(p => p.IsAddedToCart).ToListAsync();
        }

        public async Task<List<Product>> Collection()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<Product> Details(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);        
        }

        public async Task<Product> Find(int id)
        {
            return await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<int> GetCartCountAsync()
        {
            return await _appDbContext.Products.CountAsync(p => p.IsAddedToCart);

        }

        public async Task RemoveFromCart(Product product)
        {
            product.IsAddedToCart = false;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
