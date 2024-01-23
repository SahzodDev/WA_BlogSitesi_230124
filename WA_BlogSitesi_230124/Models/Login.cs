using System.ComponentModel.DataAnnotations;

namespace WA_BlogSitesi_230124.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
