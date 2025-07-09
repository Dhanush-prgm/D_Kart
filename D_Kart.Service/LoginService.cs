using D_Kart.Domain.Interfaces;
using D_Kart.Domain.Models;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _repo;

    public LoginService(ILoginRepository repo)
    {
        _repo = repo;
    }


    public LoginDetails Authenticate(string email, string password)
    {
        // Hash the password using the same method as registration
        string hashedPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        return _repo.GetByEmailAndPassword(email, hashedPassword);
    }

    public bool Register(LoginDetails user, out string error)
    {
        error = null;
        if (_repo.GetByEmail(user.Email) != null)
        {
            error = "Email already registered.";
            return false;
        }
        _repo.Add(user);
        return true;
    }
}