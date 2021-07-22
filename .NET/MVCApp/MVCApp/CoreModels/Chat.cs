using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.CoreModels
{
    public class Chat
    {
        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public int SecondUserId { get; set; }

        public DateTime? FirstUserDeleteChatTime { get; set; }

        public DateTime? SecondUserDeleteChatTime { get; set; }
    }
}
