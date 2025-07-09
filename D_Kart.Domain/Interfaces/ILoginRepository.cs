using System.Threading.Tasks;
using D_Kart.Domain.Models;

namespace D_Kart.Domain.Interfaces
{
    public interface ILoginRepository
    {
        LoginDetails GetByEmailAndPassword(string email, string password);
        LoginDetails GetByEmail(string email);
        void Add(LoginDetails user);
    }
}