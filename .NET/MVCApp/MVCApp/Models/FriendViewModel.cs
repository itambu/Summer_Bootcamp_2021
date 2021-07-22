using MVCApp.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class FriendViewModel
    {
        public int ChatId { get; set; }

        public User Friend { get; set; }
    }
}
