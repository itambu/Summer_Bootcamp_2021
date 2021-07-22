using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.CoreModels
{
    public class UserFriend
    {
        public int UserId { get; set; }

        public int FriendId { get; set; }

        public bool isVerified { get; set; }
    }
}
