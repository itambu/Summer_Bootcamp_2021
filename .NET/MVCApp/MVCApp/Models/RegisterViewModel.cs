using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User name in not defined!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email in not defined!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password in not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
