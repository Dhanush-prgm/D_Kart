using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.Domain.Interfaces.IProduct;
using D_Kart.Domain.Models;

namespace D_Kart.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddToCart(int id)
        {
            var product = await this.Find(id);

            if (product == null) return;
            await _productRepository.AddToCart(product);

        }

        public async Task<List<Product>> CartItems()
        {
            return await _productRepository.CartItems();
        }

        public async Task<List<Product>> Collection()
        {
            return await _productRepository.Collection();
        }

        public async Task<Product> Details(int id)
        {
            return await _productRepository.Details(id);
        }

        public async Task<Product> Find(int id)
        {
            return await _productRepository.Find(id);
        }

        public async Task<int> GetCartCountAsync()
        {
            return await _productRepository.GetCartCountAsync();
        }

        public async Task RemoveFromCart(int id)
        {
            var product = await this.Find(id);

            if (product == null) return;
            await _productRepository.RemoveFromCart(product);
        }
    }
}
