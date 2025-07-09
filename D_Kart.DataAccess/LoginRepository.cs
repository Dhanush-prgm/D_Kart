using D_Kart.DataAccess.Database;
using D_Kart.Domain.Interfaces;
using D_Kart.Domain.Models;


public class LoginRepository : ILoginRepository
{
    private readonly AppDbContext _appDbContext;

    public LoginRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public LoginDetails GetByEmailAndPassword(string email, string password)
    {
        return _appDbContext.LoginDetails.FirstOrDefault(u => u.Email == email && u.Password == password);
    }

    public LoginDetails GetByEmail(string email)
    {
        return _appDbContext.LoginDetails.FirstOrDefault(u => u.Email == email);
    }

    public void Add(LoginDetails user)
    {
        _appDbContext.LoginDetails.Add(user);
        _appDbContext.SaveChanges();
    }
}