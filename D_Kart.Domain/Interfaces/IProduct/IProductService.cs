using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces.IProduct
{
    public interface IProductService : IBaseService
    {
        Task<List<Product>> Collection();

        Task<List<Product>> CartItems();

        Task<Product> Details(int id);

        Task<Product> Find(int id);

        Task AddToCart(int id);

        Task RemoveFromCart(int id);

    }
}
