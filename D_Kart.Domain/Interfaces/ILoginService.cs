using D_Kart.Domain.Models;

public interface ILoginService
{
    LoginDetails Authenticate(string email, string password);
    bool Register(LoginDetails user, out string error);
}