using MVCApp.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class MessageViewModel
    {
        public int SenderId { get; set; }

        public string SenderName { get; set; }

        public int RecipientId { get; set; }

        public string RecipientName { get; set; }

        public Message Message { get; set; }

        public DateTime DateUpdate { get; set; }
    }
}
