using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Core.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Enter your mail")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Confirm your password")]
        public string ConfirmPassword { get; set; }
    }
}
