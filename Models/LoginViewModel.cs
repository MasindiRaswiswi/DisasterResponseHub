using System.ComponentModel.DataAnnotations;

namespace DisasterResponseHub.Models
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("email")]
        public string Username { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
