using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.CoreModels
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Key { get; set; }

        public int Identifier { get; set; }

        public bool IsVisible { get; set; }
    }
}
