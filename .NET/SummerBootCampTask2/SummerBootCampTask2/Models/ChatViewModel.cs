using SummerBootCampTask2.CoreModels;
using System.Collections.Generic;

namespace SummerBootCampTask2.Models
{
    public class ChatViewModel
    {
        public int Id { get; set; }

        public int FriendId { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }

        public MessageViewModel NewMessage { get; set; }
    }
}
