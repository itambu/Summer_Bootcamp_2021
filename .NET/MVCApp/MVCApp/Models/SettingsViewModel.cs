using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class SettingsViewModel
    {
        [Required(ErrorMessage = "User name in not defined!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password in not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords must match!")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

        public int Identifier { get; set; }

        public bool IsVisible { get; set; }
    }
}
