using System;

namespace SummerBootCampTask2.CoreModels
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string Data { get; set; }

        public DateTime DateUpdated { get; set; }

        public int ChatId { get; set; }
    }
}
