using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.CoreModels
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public int ChatId { get; set; }

        public string Data { get; set; }

        public DateTime DateUpdate { get; set; }

        public bool isVisible { get; set; }
    }
}
