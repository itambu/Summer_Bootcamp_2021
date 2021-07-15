using SummerBootCampTask2.CoreModels;

namespace SummerBootCampTask2.Models
{
    public class MessageViewModel
    {
        public ParticipantViewModel Sender { get; set; }

        public ParticipantViewModel Recipient { get; set; }

        public Message Message { get; set; }
    }
}
