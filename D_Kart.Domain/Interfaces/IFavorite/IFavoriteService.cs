using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces.IFavorite
{
    public interface IFavoriteService : IBaseService 
    {
        Task Add(int id);
        Task<List<Favorite>> List();
        Task Remove(Favorite favorite);
        Task<bool> Exists(int id);
        Task<Favorite> Find(int id);
    }
}
