using System.ComponentModel.DataAnnotations;

namespace SummerBootCampTask2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User name is not defined!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is not defined!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords are not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
