using System.ComponentModel.DataAnnotations;

namespace SummerBootCampTask2.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is not defined!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
