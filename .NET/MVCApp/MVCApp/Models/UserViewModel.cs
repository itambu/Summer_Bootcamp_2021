using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool isFriend { get; set; }
    }
}
