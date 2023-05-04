using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EcommerceApplication.Core.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string Email { get; set; } 
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
