namespace D_Kart.Domain.Models
{
    public class LoginDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RecoveryQuestion { get; set; }
        public string RecoveryAnswer { get; set; }
        public bool RememberMe { get; set; }
    }
}