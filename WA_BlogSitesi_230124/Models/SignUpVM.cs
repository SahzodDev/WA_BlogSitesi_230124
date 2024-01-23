using System.ComponentModel.DataAnnotations;

namespace WA_BlogSitesi_230124.Models
{
    public class SignUpVM
    {

		[Required]
		public string UserName { get; set; }

		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
    }
}
