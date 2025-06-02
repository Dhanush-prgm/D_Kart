using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces.IProduct
{
    public interface IProductRepository : IBaseRepository
    {
        Task<List<Product>> Collection();

        Task<List<Product>> CartItems();

        Task<Product> Details(int id);

        Task<Product> Find(int id);

        Task AddToCart(Product product);

        Task RemoveFromCart(Product product);

    }
}
