using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Kart.Domain.Interfaces
{
    public interface IBaseRepository
    {
        Task<int> GetCartCountAsync();
    }
}
