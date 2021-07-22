using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email in not defined!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password in not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
