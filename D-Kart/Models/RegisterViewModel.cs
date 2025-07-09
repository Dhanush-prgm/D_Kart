using System.ComponentModel.DataAnnotations;

namespace D_Kart.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string RecoveryQuestion { get; set; }
        public string RecoveryAnswer { get; set; }
    }
}
