using SummerBootCampTask2.CoreModels;
using System.Collections.Generic;

namespace SummerBootCampTask2.Models
{
    public class ChatViewModel
    {
        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public int SecondUserId { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public Message NewMessage { get; set; }
    }
}
